class Pair {
    int x;
    int y;

    Pair(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public String toString() {
        String temp;
        temp = "(" + this.x + "," + this.y + ")";
        return temp;
    }
}

public class algorithm {

    public static int xnum = 100;
    public static int ynum = 20;

    static int[][] surveys = new int[xnum][ynum];
    static int[][] clusters = new int[xnum][xnum];
    static double[][] distances = new double[xnum][ynum];
    static double avgdist;
    static char[][] table = new char[xnum][xnum];
    static Pair[] pairs = new Pair[(xnum * xnum)];
    static int counter = 0;
    static double multiplier = 1;
    static boolean pairflag = false;

    public static void main(String args[]) {

        populate();
        distances = distarray(surveys);
        populatecluster();
        checkclust(distances);
        sortpairs();

        /*
        System.out.println("The matrix of all surveys/ rows are indivuduals and colums are their order");
        twostring(surveys);
        System.out.println();
        System.out.println("The distance bewteen each individual in n-dimensional space");
        twostring(distances);
        System.out.println();
        System.out.println("the average distance between points");
        System.out.println(avgdist);
        System.out.println();
        System.out.println("whether each point is within range of another");
        twostring(table);
        System.out.println();
        System.out.println("The points as corridinates, There are: " + counter);
        printpairs(pairs);
        System.out.println();
        System.out.println();
        System.out.println("The clusters");
        twostring(clusters);
        System.out.println();
        */


        System.out.println("There are " + find(clusters) + " clusters with " + xnum + " participants and " + ynum + " questions on the survey");
    }


    private static void printpairs(Pair[] pairs2) {

        for (int i = 0; i < counter; i++) {
            System.out.print(pairs[i].toString());
        }

    }


    public static String onestring(int[] x) {
        String temp = "";
        temp += x[0];
        for (int i = 1; i < x.length; i++) {
            temp += " " + x[i];
        }
        return temp;
    }

    public static void twostring(int[][] x) {

        for (int k = 0; k < x.length; k++) {
            for (int i = 0; i < x[k].length; i++) {
                //System.out.print("   k=" + k + " i=" +i + " ");
                if (x[k][i] != -1)
                    System.out.print(" " + x[k][i]);
            }
            System.out.println();
        }

    }

    public static void twostring(char[][] x) {

        for (int k = 0; k < x.length; k++) {
            for (int i = 0; i < x[k].length; i++) {
                //System.out.print("   k=" + k + " i=" +i + " ");
                System.out.print(" " + x[k][i]);
            }
            System.out.println();
        }

    }

    public static void twostring(double[][] x) {

        for (int k = 0; k < x.length; k++) {
            for (int i = 0; i < x[k].length; i++) {
                //System.out.print("   k=" + k + " i=" +i + " ");
                System.out.print(" " + x[k][i]);
            }
            System.out.println();
        }

    }

    public static double distance(int[] x, int[] y) {
        double dist;
        double temp = 0;
        for (int i = 0; i < x.length; i++) {
            temp += Math.pow(x[i] - y[i], 2);
        }
        dist = Math.sqrt(temp);

        return dist;

    }

    public static double[][] distarray(int[][] x) {
        double[][] matrix = new double[xnum][xnum];
        double totaldist = 0;
        int count = 0;
        for (int i = 0; i < x.length; i++) {
            for (int j = i; j < x.length; j++) {
                totaldist += distance(x[i], x[j]);
                count++;
                matrix[i][j] = distance(x[i], x[j]);
            }
        }
        avgdist = (totaldist / (count - x.length));
        return matrix;

    }

    public static void populate() {

        for (int i = 0; i < surveys.length; i++) {
            for (int j = 0; j < surveys[i].length; j++) {
                surveys[i][j] = (int) (Math.random() * surveys[i].length);

                for (int k = 0; k < j; k++) {
                    if (surveys[i][j] == surveys[i][k]) {
                        j--; //if a[i] is a duplicate of a[j], then run the outer loop on i again
                        break;
                    }
                }
            }
        }
    }

    public static void populatecluster() {

        for (int i = 0; i < clusters.length; i++) {
            for (int j = 0; j < clusters[i].length; j++) {
                clusters[i][j] = -1;
            }
        }
    }

    public static void checkclust(double[][] x) {
        for (int i = 0; i < x.length; i++) {
            for (int j = i; j < x.length; j++) {
                if (i == j) {
                    table[i][j] = 'x';
                } else if (x[i][j] <= avgdist * multiplier) {
                    table[i][j] = 'T';
                    pairs[counter] = new Pair(i, j);
                    pairflag = true;
                    counter++;
                } else if (x[i][j] > avgdist * multiplier) {
                    table[i][j] = 'F';
                }
            }
        }
    }

    public static void sortpairs() {
        int tempx;
        int tempy;
        int zz;
        int row;
        if (pairflag == false) {
            for (int i = 0; i < xnum; i++) {
                if (!(check(i, clusters))) {
                    zz = find(clusters);
                    clusters[zz][0] = i;
                }
            }
            return;
        }
        tempx = pairs[0].x;
        tempy = pairs[0].y;
        clusters[0][0] = tempx;
        clusters[0][1] = tempy;
        for (int i = 0; i < counter; i++) {
            //System.out.println(pairs[i].toString());
            tempx = pairs[i].x;
            tempy = pairs[i].y;


            if (!(check(tempx, clusters) || check(tempy, clusters))) {
                //System.out.println("FLAG1 ");
                zz = find(clusters);
                clusters[zz][0] = tempx;
                clusters[zz][1] = tempy;

            } else if (check(tempx, clusters) && check(tempy, clusters)) {
                //System.out.println("FLAG4 ");
                if (!(findrow(tempx, clusters) == findrow(tempy, clusters))) {
                    //mergecluster
                    merge(findrow(tempx, clusters), findrow(tempy, clusters));
                    //System.out.println("merge needed: x:"+tempx+" y:"+tempy);
                }
            } else if (check(tempx, clusters)) {
                //System.out.println("FLAG2 ");
                row = findrow(tempx, clusters);
                clusters[row][find(clusters[row])] = tempy;

            } else if (check(tempy, clusters)) {
                //System.out.println("FLAG3 ");
                row = findrow(tempy, clusters);
                clusters[row][find(clusters[row])] = tempx;

            }
        }

        for (int i = 0; i < xnum; i++) {
            if (!(check(i, clusters))) {
                zz = find(clusters);
                clusters[zz][0] = i;
            }
        }

    }

    //}
    //checks if a number is in the array
    public static boolean check(int x, int[][] y) {
        for (int i = 0; i < y.length; i++) {
            for (int j = 0; j < y[i].length; j++)
                if (x == y[i][j]) {
                    return true;
                }
        }
        return false;
    }

    public static int find(int[] y) {
        for (int i = 0; i < y.length; i++) {
            if (y[i] == -1) {
                return i;
            }
        }
        return 0;
    }

    public static int find(int[][] y) {
        for (int i = 0; i < y.length; i++) {
            if (y[i][0] == -1) {
                return i;
            }
        }
        return xnum;
    }

    public static int findrow(int x, int[][] y) {
        for (int i = 0; i < y.length; i++) {
            for (int j = 0; j < y[i].length; j++)
                if (x == y[i][j]) {
                    return i;
                }
        }
        return 0;
    }

    public static void merge(int x, int y) {
        int j = 0;
        int i = find(clusters[x]);
        while (clusters[y][j] != -1) {
            clusters[x][i] = clusters[y][j];
            j++;
            i++;
        }

        //for(int j = 0;clusters[x][j]!= -1; j++){
        //clusters[x][i] = clusters[y][j];
        //}
        for (int k = 0; k < clusters[y].length; k++) {
            //System.out.println("y ="+y+ " k ="+k);
            clusters[y][k] = -1;
        }
    }
}

