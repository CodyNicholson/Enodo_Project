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

namespace Capstone_Project.Controllers
{
    public class person
    {

        public String name;
        public int num;
        public int Genderid;
        public String Gender;
        public String Demographic;
        public int Demographicid;
        public String Country;
        public double[] numanswers;
        public String[] stringans;

        public person(int p, double[] arr)
        {
            this.name = "" + p;
            this.num = p;
            this.Genderid = p;
            this.Demographicid = p;
            this.Gender = "" + p;
            this.Demographic = "" + p;
            this.numanswers = arr;
            this.stringans = new String[arr.Length];
            //answers = arr.ToString();
        }
        public void setname(int id, ApplicationDbContext _context)
        {
            var survey = _context.AppUsers.SingleOrDefault(s => s.Id == id);
            
            this.name = survey.Name; ; //Grabs the name using the user id
            this.Genderid = survey.GenderId;
            this.Demographicid = survey.DemographicId;
            this.Country = survey.Country;
            var gender = _context.Genders.SingleOrDefault(s => s.Id == this.Genderid);
            this.Gender = gender.GenderName;
            var demo = _context.Demographics.SingleOrDefault(s => s.Id == this.Demographicid);
            

        }

        public void setans(int id, ApplicationDbContext _context)
        {
            var tempoptions = _context.Options.Where(s => s.SurveyId == id);
            var temparr = tempoptions.ToArray();
            for (int i = 0; i < temparr.Length; i++)
            {
                this.stringans[i] = temparr[(int)this.numanswers[i]].Name;

            }
        }
        public void setnum(int id)
        {
            this.num = id;
        }

        public String toString()
        {
            return this.name;
        }
    }
    class cluster
    {
        public String name;
        public double[] midpoint;
        public int[] like;
        public int[] dislike;
        public int far;
        public double fardist;

        public ArrayList children = new ArrayList();

        public cluster(int p, double[] point, int x, int y)
        {
            this.name = "Cluster " + y;
            this.children.Add(new person(p,point));
            this.midpoint = point;
            this.like = new int[x];
            this.dislike = new int[x];
            this.far = p;
            this.fardist = 0;
        }

        public void add(int x, double[] arr)
        {
            children.Add(new person(x,arr));
            updatemid(arr);
            updatefurthest(x, arr);

        }

        public double[] getmid()
        {
            return this.midpoint;
        }
        public void updatemid(double[] arr)
        {

            double[] tempmid = new double[midpoint.Length];
            for (int i = 0; i < midpoint.Length; i++)
            {
                tempmid[i] = midpoint[i] * (children.Count - 1);
            }
            for (int i = 0; i < midpoint.Length; i++)
            {
                tempmid[i] += arr[i];
            }
            for (int i = 0; i < midpoint.Length; i++)
            {
                tempmid[i] = tempmid[i] / children.Count;
            }
            this.midpoint = tempmid;
        }

        public void updatelike(double[] x)
        {
            int like1 = (int)x[0];
            int like2 = (int)x[1];
            int like3 = (int)x[2];
            int dislike1 = (int)x[x.Length - 1];
            int dislike2 = (int)x[x.Length - 2];
            int dislike3 = (int)x[x.Length - 3];
            this.like[like1] = this.like[like1] + 1;
            this.like[like2] = this.like[like2] + 1;
            this.like[like3] = this.like[like3] + 1;
            this.dislike[dislike1] = this.dislike[dislike1] + 1;
            this.dislike[dislike2] = this.dislike[dislike2] + 1;
            this.dislike[dislike3] = this.dislike[dislike3] + 1;
        }

        public void updatename(person y, int[] x, ApplicationDbContext _context)
        {
            y.setnum(x[y.num]);
            y.setname(y.num, _context);
        }

        public void updateans(person y, int x, ApplicationDbContext _context)
        {
            y.setans(x, _context);
        }


        public void updatefurthest(int p, double[] x)
        {
            if (distance(x, this.midpoint) > fardist)
            {
                this.far = p;
                this.fardist = distance(x, this.midpoint);
            }

        }
        public bool isincluster(double[] x, double dist)
        {

            if (distance(x, midpoint) < dist)
            {
                return true;
            }
            return false;
        }

        public Double disttomid(double[] x)
        {
            return distance(x, midpoint);
        }
        public void print()
        {
            Console.WriteLine("The midpoint " + print2darray(this.midpoint));
            Console.WriteLine("the furthest point is person " + this.far + " that is " + this.fardist + " away from the center.");
            Console.WriteLine("The amount of the children in this cluster " + this.children.Count);
            Console.WriteLine("The children in this cluster");
            printchildren(children);
            Console.Write("The most common likes in this cluster are ");
            printtopthree();
            //Console.WriteLine(print2darray(like));
            Console.Write("The most common dislikes in this cluster are ");
            printbotthree();
            //Console.WriteLine(print2darray(dislike));
        }

        public void printbotthree()
        {

            int temp1 = 0;
            int index1 = 0;
            int temp2 = 0;
            int index2 = 0;
            int temp3 = 0;
            int index3 = 0;
            for (int i = 0; i < this.dislike.Length; i++)
            {
                if (this.dislike[i] > temp1)
                {
                    temp3 = temp2;
                    index3 = index2;
                    temp2 = temp1;
                    index2 = index1;
                    temp1 = this.dislike[i];
                    index1 = i;
                }
                else if (this.dislike[i] > temp2)
                {
                    temp3 = temp2;
                    index3 = index2;
                    temp2 = this.dislike[i];
                    index2 = i;
                }
                else if (this.dislike[i] > temp3)
                {
                    temp3 = this.dislike[i];
                    index3 = i;

                }
            }

            Console.WriteLine(index1 + " " + index2 + " " + index3);


        }

        public void printtopthree()
        {
            int temp1 = 0;
            int index1 = 0;
            int temp2 = 0;
            int index2 = 0;
            int temp3 = 0;
            int index3 = 0;
            for (int i = 0; i < this.like.Length; i++)
            {
                if (this.like[i] > temp1)
                {
                    temp3 = temp2;
                    index3 = index2;
                    temp2 = temp1;
                    index2 = index1;
                    temp1 = this.like[i];
                    index1 = i;
                }
                else if (this.like[i] > temp2)
                {
                    temp3 = temp2;
                    index3 = index2;
                    temp2 = this.like[i];
                    index2 = i;
                }
                else if (this.like[i] > temp3)
                {
                    temp3 = this.like[i];
                    index3 = i;

                }
            }

            Console.WriteLine(index1 + " " + index2 + " " + index3);

        }

        public String print2darray(double[] x)
        {
            String temp = "";
            for (int i = 0; i < x.Length; i++)
            {
                temp = temp + x[i] + " ";
            }
            return temp;

        }
        public String print2darray(int[] x)
        {
            String temp = "";
            for (int i = 0; i < x.Length; i++)
            {
                temp = temp + x[i] + " ";
            }
            return temp;

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

        public static void printchildren(ArrayList x)
        {
            foreach (person i in x)
            {
                Console.Write("" + i.num + ", ");
            }
            Console.WriteLine();
        }
    }
}
