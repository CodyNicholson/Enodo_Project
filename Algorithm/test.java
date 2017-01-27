package capstone;

import java.util.ArrayList;

public class test extends cluster {

    public test(int p, double[] point, int x) {
        super(p, point, x);
        // TODO Auto-generated constructor stub
    }

    public static ArrayList<cluster> clusters = new ArrayList<cluster>();
    public static int xnum =20;//the number of surveys
    public static int ynum =20;//the number of questions


    static double[][] surveys = new double[xnum][ynum];

    static boolean addedflag = false;
    static double avgdist = 0;

    public static void main(String args[]){

        populate();
        //twostring(surveys);
        distarray(surveys);
        System.out.println("avgdist is " + avgdist);
        System.out.println();

        clusters.add(new cluster(0,surveys[0],ynum));
        for(int i = 1;i<surveys.length;i++){
            addedflag = false;
            for(int k = 0; k <clusters.size();k++){
                if(clusters.get(k).isincluster(surveys[i], avgdist*1) && !addedflag){
                    //System.out.println(i+" is in the cluster");
                    clusters.get(k).add(i, surveys[i]);
                    addedflag=true;
                }
            }
            if(!addedflag){
                clusters.add(new cluster(i,surveys[i],ynum));
            }

        }
        for(int k = 0; k <clusters.size();k++){
            for(int x :clusters.get(k).people){
                clusters.get(k).updatelike(surveys[x]);
            }
        }


        System.out.println("There are " + clusters.size()+ " clusters with a total of "+xnum+" surveys and "+ ynum+ " questions");
        System.out.println();
        printclusters();
        System.out.println("There are " + clusters.size()+ " clusters with a total of "+xnum+" surveys and "+ ynum+ " questions");
        System.out.println();
    }

    public static void printclusters(){
        for(int i = 0; i <clusters.size();i++){
            clusters.get(i).print();
            System.out.println();
        }
    }

    public static void populate(){

        for(int i = 0;i <surveys.length;i++){
            for(int j = 0; j<surveys[i].length;j++){
                surveys[i][j]= (int)(Math.random()*surveys[i].length);

                for (int k = 0; k < j; k++) {
                    if (surveys[i][j] == surveys[i][k]) {
                        j--; //if a[i] is a duplicate of a[j], then run the outer loop on i again
                        break;
                    }
                }
            }
        }
    }
    public static void twostring(double[][] x){

        for(int k = 0; k<x.length;k++){
            for(int i = 0;i<x[k].length;i++){
            //System.out.print("   k=" + k + " i=" +i + " ");
            System.out.print( " " + x[k][i]);
            }
            System.out.println();
        }

    }

    public static void distarray(double[][] x){
        double totaldist =0;
        int count = 0;
        for(int i=0;i < x.length;i++){
            for(int j =i; j<x.length;j++){
                totaldist+=distance(x[i],x[j]);
                count++;
            }
        }
        avgdist = (totaldist/(count-x.length));

    }

}