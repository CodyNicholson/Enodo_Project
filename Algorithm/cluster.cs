using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication6
{
    class cluster
    {
        public double[] midpoint;
        public ArrayList people = new ArrayList();
        int[] like;
        int[] dislike;

        int far;
        double fardist;

        public cluster(int p, double[] point, int x)
        {
            this.people.Add(p);
            this.midpoint = point;
            this.like = new int[x];
            this.dislike = new int[x];
            this.far = p;
            this.fardist = 0;
        }

        public void add(int x, double[] arr)
        {
            people.Add(x);
            updatemid(arr);
            updatefurthest(x, arr);

        }
        public void updatemid(double[] arr)
        {
           
            double[] tempmid = new double[midpoint.Length];
            for (int i = 0; i < midpoint.Length; i++)
            {
                tempmid[i] = midpoint[i] * (people.Count - 1);
            }
            for (int i = 0; i < midpoint.Length; i++)
            {
                tempmid[i] += arr[i];
            }
            for (int i = 0; i < midpoint.Length; i++)
            {
                tempmid[i] = tempmid[i] / people.Count;
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
            Console.WriteLine("The amount of the people in this cluster " + this.people.Count);
            Console.WriteLine("The people in this cluster");
            printpeople(people);
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

        public static void printpeople(ArrayList x)
        {
            foreach(int i in x)
            {
                Console.Write("" + i + ", ");
            }
            Console.WriteLine();
        }
    }
}
