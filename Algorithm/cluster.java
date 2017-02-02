package capstone;

import java.util.ArrayList;

public class cluster {
	
	double[] midpoint;
	ArrayList<Integer> people = new ArrayList<Integer>();
	int[] like;
	int[] dislike;
	
	int far;
	double fardist;
	
	public cluster(int p, double[] point,int x){
		this.people.add(p);
		this.midpoint = point;
		this.like= new int[x];
		this.dislike= new int[x];
		this.far = p;
		this.fardist = 0;
	}
	
	public void add(int x,double[] arr){
		people.add(x);
		updatemid(arr);
		updatefurthest(x,arr);
		
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
		this.dislike[dislike1]= this.dislike[dislike1]+1;
		this.dislike[dislike2]= this.dislike[dislike2]+1;
		this.dislike[dislike3]= this.dislike[dislike3]+1;
	}
	
	public void updatefurthest(int p, double[] x){
		if(distance(x,this.midpoint)>fardist){
			this.far = p;
			this.fardist = distance(x,this.midpoint);
		}

	}
	public boolean isincluster(double[] x,double dist){
		
		if(distance(x,midpoint)<dist){
			return true;
		}
		return false;
	}
	
	public Double disttomid(double[] x){	
		return distance(x,midpoint);
	}
	public void print(){
		System.out.println("The midpoint "+ print2darray(this.midpoint));
		System.out.println("the furthest point is person "+ this.far + " that is "+ this.fardist + " away from the center.");
		System.out.println("The amount of the people in this cluster "+ this.people.size());
		System.out.println("The people in this cluster"+ this.people.toString());
		System.out.print("The most common likes in this cluster are ");
		printtopthree();
		//System.out.println(print2darray(like));
		System.out.print("The most common dislikes in this cluster are ");
		printbotthree();
		//System.out.println(print2darray(dislike));
	}
	
	public void printbotthree(){

		int temp1 =0;
		int index1 = 0;
		int temp2 =0;
		int index2 = 0;
		int temp3 =0;
		int index3 = 0;
		for(int i = 0;i < this.dislike.length;i++){
			if(this.dislike[i]>temp1){
				temp3=temp2;
				index3 = index2;
				temp2=temp1;
				index2 = index1;
				temp1=this.dislike[i];
				index1 = i;
			}
			else if(this.dislike[i]>temp2){
				temp3=temp2;
				index3 = index2;
				temp2=this.dislike[i];
				index2 = i;
			}
			else if(this.dislike[i]>temp3){
				temp3=this.dislike[i];
				index3 = i;
				
			}
		}
		
		System.out.println(index1 + " " + index2 + " " + index3);
		
		
	}
	
	public void printtopthree(){
		int temp1 =0;
		int index1 = 0;
		int temp2 =0;
		int index2 = 0;
		int temp3 =0;
		int index3 = 0;
		for(int i = 0;i < this.like.length;i++){
			if(this.like[i]>temp1){
				temp3=temp2;
				index3 = index2;
				temp2=temp1;
				index2 = index1;
				temp1=this.like[i];
				index1 = i;
			}
			else if(this.like[i]>temp2){
				temp3=temp2;
				index3 = index2;
				temp2=this.like[i];
				index2 = i;
			}
			else if(this.like[i]>temp3){
				temp3=this.like[i];
				index3 = i;
				
			}
		}
		
		System.out.println(index1 + " " + index2 + " " + index3);
		
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
