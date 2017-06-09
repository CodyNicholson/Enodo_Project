using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web;
using System.Web.Mvc;
using Capstone_Project.Models;
using Capstone_Project.ViewModel;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Data;
using System.IO;

namespace Capstone_Project.Controllers
{

    public class dummy
    {

        public String name;
        public int amount;
        public String[] options;
        public ArrayList children;


        public dummy(String x, ArrayList y, int z, String[] arr)
        {

            this.name = x;
            this.children = y;
            this.options = arr;
            this.amount = z;

        }
    }

    class test
    {
        public static Random random = new Random();
        public static ArrayList clusters = new ArrayList();
        public static ArrayList tempal = new ArrayList();
        public static int xnum = 20;//the number of surveys
        public static int ynum = 20;//the number of questions


        private static ApplicationDbContext database = new ApplicationDbContext();


        static double[][] surveys;
        static string[] maparr;


        static double avgdist = 0;
        static double avgdistmulti = .8;



        public static void runAlgorithm(int surveyid, ApplicationDbContext _context)
        {
            clusters.Clear();
            List <ApplicationUser> list = database.Users.ToList();
            //Console.WriteLine(list.ToString());
            //var rywjhs  = Console.In;
            //double[][] xyzaffair = parsetable(surveyid, _context);
            //parsetable(surveyid);
            /*maparr = new string[xyzaffair.Length-1];
            for(int i = 0;i < xyzaffair[0].Length; i++)
            {
                maparr[i] = xyzaffair[0][i].ToString();
            }
            
            surveys = new double[xyzaffair.Length - 1][];
            for(int x = 1; x < xyzaffair.Length; x++)
            {
                surveys[x-1] = xyzaffair[x];
            }*/
            //surveys = xyzaffair;

            parsetable(surveyid, _context);
            distarray(surveys);



            Double bestfit = 9999999999.0;
            int bestfitindex = 0;
            bool addedflag = false;
            clusters.Add(new cluster(0, surveys[0], surveys[0].Length, 1));
            for (int i = 1; i < surveys.Length; i++)
            {
                bestfit = 9999999999.0;
                bestfitindex = 0;
                addedflag = false;
                for (int k = 0; k < clusters.Count; k++)
                {
                    cluster c = (cluster)clusters[k];
                    if (((cluster)(clusters[k])).isincluster(surveys[i], avgdist * avgdistmulti) && !addedflag)
                    {
                        //Console.WriteLine(i+" is in the cluster");
                        tempal.Add(k);


                        //clusters.get(k).add(i, surveys[i]);
                        //addedflag=true;
                    }
                }
                if (tempal.Count > 0)
                {
                    foreach (int j in tempal)
                    {
                        if (((cluster)(clusters[j])).disttomid(surveys[i]) < bestfit)
                        {
                            bestfitindex = j;
                            bestfit = ((cluster)(clusters[j])).disttomid(surveys[i]);
                        }
                    }
                    ((cluster)(clusters[bestfitindex])).add(i, surveys[i]);
                    addedflag = true;
                }
                if (!addedflag)
                {
                    clusters.Add(new cluster(i, surveys[i], surveys[i].Length, clusters.Count + 1));
                }

            }
            for (int k = 0; k < clusters.Count; k++)
            {
                foreach (person x in ((cluster)(clusters[k])).children)
                {
                   // ((cluster)(clusters[k])).updatelike(surveys[x.num]);
                }
            }

            for (int k = 0; k < clusters.Count; k++)
            {
                foreach (person x in ((cluster)(clusters[k])).children)
                {
                    ((cluster)(clusters[k])).updatename(x, maparr, _context);
                }
            }

            for (int k = 0; k < clusters.Count; k++)
            {
                foreach (person x in ((cluster)(clusters[k])).children)
                {
                    ((cluster)(clusters[k])).updateans(x, surveyid, _context);
                }
            }

            tempal.Clear();
            


        }

        public static void createjson(int surveyid, ApplicationDbContext _context)
        {
            var tempoptions = _context.Options.Where(s => s.SurveyId == surveyid);
            var temparr = tempoptions.ToArray();
            String[] arr = new String[temparr.Length];
            for(int i = 0; i < temparr.Length; i++)
            {
                arr[i] = temparr[i].Name;
            }


            dummy tempdummy = new dummy("Clusters Survey#"+surveyid  , clusters, clusters.Count,arr);
            var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(tempdummy);
            var json2 = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(clusters);
            //String outputadd = "C:/Users/Brian/Desktop/Brian's stuf/College/Senior/winter/capstone/Capstone_Project-master/Enodo/Capstone_Project/Scripts/_output" + surveyid + ".json";
            String outputadd = "C:/Users/Cody/GitHub/Capstone_Project/Enodo/Capstone_Project/Scripts/_output" + surveyid + ".json";
            //String outputadd = "C:/Users/Brian/Desktop/Brian's stuf/College/Senior/winter/capstone/Capstone_Project-master/Enodo/Capstone_Project/Scripts/_output" + surveyid + ".json";
            //String outputadd = "../Scripts/_output" + surveyid + ".json";

            /*
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json2);
            StringBuilder sb = new StringBuilder();

            foreach (DataColumn col in dt.Columns)
            {
                sb.Append(col.ColumnName + ',');
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(Environment.NewLine);

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(row[i].ToString() + ",");
                }

                sb.Append(Environment.NewLine);
            }

            System.IO.File.WriteAllText("C:/Users/Brian/Desktop/Brian's stuf/College/Senior/winter/capstone/Capstone_Project-master/Enodo/Capstone_Project/Scripts/_output" + surveyid +".csv", sb.ToString());

            */
            //System.IO.File.WriteAllText("2" + outputadd, json2);

            string path = HttpContext.Current.Server.MapPath("~/Scripts/_output" + surveyid + ".json");

            json = "[" + json + "]";
            System.IO.File.WriteAllText(path, json);

        }

        public static void parsetable(int surveyid, ApplicationDbContext _context)
        {
            var results = _context.SurveyResultsSet.Where(s => s.SurveyId == surveyid);
            var array = results.ToArray();
            int x = array.Length;
            surveys = new double[x][];
            maparr = new String[x];
            
            for (int i = 0; i < x; i++)
            {
                maparr[i] = array[i].UserId;
                surveys[i] = array[i].OptionOrder.Split(',').Select(Double.Parse).ToArray();
            }
            //return temp;
        }



        /*
        public static int Main(string[] args)
        {

            for(int i = 0; i< xnum; i++)
            {
                surveys[i] = new double[ynum];
            }
            populate();
            //twostring(surveys);
            distarray(surveys);
            Console.WriteLine("avgdist is " + avgdist);
            Console.WriteLine();

            Double bestfit = 9999999999.0;
            int bestfitindex = 0;
            bool addedflag = false;
            clusters.Add(new cluster(0, surveys[0], ynum,1));
            for (int i = 1; i < surveys.Length; i++)
            {
                bestfit = 9999999999.0;
                bestfitindex = 0;
                addedflag = false;
                for (int k = 0; k < clusters.Count; k++)
                {
                   cluster c = (cluster)clusters[k];
                    if (((cluster)(clusters[k])).isincluster(surveys[i], avgdist * avgdistmulti) && !addedflag)
                    {
                        //Console.WriteLine(i+" is in the cluster");
                        tempal.Add(k);


                        //clusters.get(k).add(i, surveys[i]);
                        //addedflag=true;
                    }
                }
                if (tempal.Count > 0)
                {
                    foreach (int j in tempal)
                    {
                        if (((cluster)(clusters[j])).disttomid(surveys[i]) < bestfit) ;
                        {
                            bestfitindex = j;
                            bestfit = ((cluster)(clusters[j])).disttomid(surveys[i]);
                        }
                    }
                    ((cluster)(clusters[bestfitindex])).add(i, surveys[i]);
                    addedflag = true;
                }
                if (!addedflag)
                {
                    clusters.Add(new cluster(i, surveys[i], ynum,clusters.Count + 1));
                }

            }
            for (int k = 0; k < clusters.Count; k++)
            {
                foreach (person x in ((cluster)(clusters[k])).children)
                {
                    ((cluster)(clusters[k])).updatelike(surveys[x.num]);
                }
            }


            Console.WriteLine("There are " + clusters.Count + " clusters with a total of " + xnum + " surveys and " + ynum + " questions");
            Console.WriteLine();
            printclusters();
            Console.WriteLine("There are " + clusters.Count + " clusters with a total of " + xnum + " surveys and " + ynum + " questions");
            Console.WriteLine("the average distance between the clusters is: " + clusterdist(clusters));
            Console.WriteLine("avgdist is " + avgdist);

            dummy tempdummy = new dummy("Clusters", clusters,clusters.Count);
            var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(tempdummy);
            //Console.WriteLine(json);
           // System.IO.File.WriteAllText("C:/Users/Brian/Desktop/test4.json", json);

            Console.Read();
            return 1;
        }*/

        public static void printclusters()
        {
            for (int i = 0; i < clusters.Count; i++)
            {
                Console.WriteLine("Cluster number " + (i + 1));
                ((cluster)clusters[i]).print();
                Console.WriteLine();
            }
        }

        public static void populate()
        {

            for (int i = 0; i < surveys.Length; i++)
            {
                for (int j = 0; j < surveys[i].Length; j++)
                {

                    surveys[i][j] = random.Next(0, surveys[i].Length);

                    for (int k = 0; k < j; k++)
                    {
                        if (surveys[i][j] == surveys[i][k])
                        {
                            j--; //if a[i] is a duplicate of a[j], then run the outer loop on i again
                            break;
                        }
                    }
                }
            }
        }
        public static void twostring(double[][] x)
        {

            for (int k = 0; k < x.Length; k++)
            {
                for (int i = 0; i < x[k].Length; i++)
                {
                    //Console.Write("   k=" + k + " i=" +i + " ");
                    Console.Write(" " + x[k][i]);
                }
                Console.WriteLine();
            }

        }

        public static void distarray(double[][] x)
        {
            double totaldist = 0;
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = i; j < x.Length; j++)
                {
                    totaldist += distance(x[i], x[j]);
                    count++;
                }
            }
            avgdist = (totaldist / (count - x.Length));
        }

        public static Double clusterdist(ArrayList x)
        {
            double totaldist = 0;
            int count = 0;
            for (int i = 0; i < x.Count; i++)
            {
                for (int j = i + 1; j < x.Count; j++)
                {
                    totaldist += distance(((cluster)x[i]).getmid(), ((cluster)x[j]).getmid());
                    //Console.WriteLine("the distance between cluster " + i + " and cluster "+ j+" is "+distance(x.get(i).midpoint,x.get(j).midpoint));
                    count++;
                }
            }
            return (totaldist / (count));
        }
        public static double distance(double[] x, double[] y)
        {
            double dist;
            double temp = 0;
            for (int i = 0; i < x.Length; i++)
            {

                temp += Math.Pow(x[i] - y[i], 2);
            }
            dist = Math.Sqrt(temp);

            return dist;

        }

    }
}
