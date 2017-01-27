package capstone;

import java.util.ArrayList;

public class cluster {

    double[] midpoint;
    ArrayList<Integer> people = new ArrayList<Integer>();
    int[] like;
    int[] dislike;

    public cluster(int p, double[] point,int x){
        this.people.add(p);
        this.midpoint = point;
        this.like= new int[x];
        this.dislike= new int[x];
    }

    public void add(int x,double[] arr){
        people.add(x);
        updatemid(arr);

    }
    public void updatemid(double[] arr){
        double[] tempmid = new double[midpoint.length];
        for(int i = 0;i<midpoint.length;i++){
            tempmid[i]=midpoint[i] * (people.size()-1);
        }
        for(int i = 0;i<midpoint.length;i++){
            tempmid[i]+=arr[i];
        }
        for(int i = 0;i<midpoint.length;i++){
            tempmid[i] = tempmid[i]/people.size();
        }
        this.midpoint=tempmid;
    }

    public void updatelike(double[] x){
        int like1 = (int)x[0];
        int like2 = (int)x[1];
        int like3 = (int)x[2];
        int dislike1 = (int)x[x.length-1];
        int dislike2 = (int)x[x.length-2];
        int dislike3 = (int)x[x.length-3];
        this.like[like1]= this.like[like1]+1;
        this.like[like2]= this.like[like2]+1;
        this.like[like3]= this.like[like3]+1;
        this.dislike[dislike1]= this.like[dislike1]+1;
        this.dislike[dislike2]= this.like[dislike2]+1;
        this.dislike[dislike3]= this.like[dislike3]+1;
    }

    public double[] findneighbor(double[][] x){
        double[] temp = new double[x[0].length];

        return temp;
    }
    public boolean isincluster(double[] x,double dist){

        if(distance(x,midpoint)<dist){
            return true;
        }
        return false;
    }

    public void print(){
        System.out.println("The midpoint "+ print2darray(this.midpoint));
        System.out.println("The amount of the people in this cluster "+ this.people.size());
        System.out.println("The people in this cluster"+ this.people.toString());
        System.out.println("The most common likes in this cluster are");
        System.out.println(print2darray(like));
        System.out.println("The most common dislikes in this cluster are");
        System.out.println(print2darray(dislike));
    }

    public String print2darray(double[] x){
        String temp = "";
        for(int i = 0;i<x.length;i++){
            temp= temp +x[i]+ " ";
        }
        return temp;

    }
    public String print2darray(int[] x){
        String temp = "";
        for(int i = 0;i<x.length;i++){
            temp= temp +x[i]+ " ";
        }
        return temp;

    }


    public static double distance(double[] x,double[] y){
        double dist;
        double temp=0;
        for(int i = 0 ;i<x.length;i++){
                temp+= Math.pow(x[i]-y[i],2);
        }
        dist = Math.sqrt(temp);

        return dist;

    }
}