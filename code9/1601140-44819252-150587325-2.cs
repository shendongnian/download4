            using System;
            using System.IO;
            using System.Text;
            using System.Drawing;
            using System.Collections;
            using System.ComponentModel;
            using System.Windows.Forms;
            using System.Data;
            using System.Threading;
            using AUV_Topology;
            using System.Collections.Generic;
            using System.Media;
            using System.Linq;
        
            namespace AUVtopology
            {
                public partial class Form1 : Form
                {        
                  static int[,] array;
                  static List<int[]> path;
            //This method is used to make sure the coordinate array 
            //is contained in the list. List.contains(new int[] {val1,val2}) was not enough.
            static Boolean containsArray(List<int[]> list, int[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return false;
                }
                foreach (var listArray in list)
                {
                    if (listArray != null && listArray.Length == array.Length)
                    {
                        for (int i = 0; i < listArray.Length; i++)
                        {
                            if (array[i] != listArray[i])
                            {
                                continue;
                            }
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }    
            
            //This is the recursive method of the algorithm. It finds the 
            //maximum path of 1 cells in a matrix of 0/1 cells
            static List<int[]> getMaxPath(int[,] array, List<int[]> maxPath, int rowIndex, int colIndex)
            {  
    
                     //Add the current cell to the path.
                     maxPath.Add(new int[]{rowIndex,colIndex});
    
                     //Get the array limits.
                     int rowLength = array.GetLength(0);
                     int colLength = array.GetLength(1);
    
                     //If the path contains all the cells in the matrix, stop
                     if (maxPath.Count >= rowLength * colLength) {
                         return maxPath;
                     }
                     //remove one from lengths to make it the maximum index
                     colLength = colLength - 1;
                     rowLength = rowLength - 1;
                     //We'll use this variables to see which of the 
                     //potential 7 paths is the longest.
                     List<int[]> futurePath;
    
                     //Go over all 8 possible adjoining cells:
                     //If we can go one down, one right, and it's a spot we 
                     //have not yet visited
                     if (colIndex < colLength && rowIndex < rowLength && 
                         array[rowIndex+1,colIndex+1]==1 && 
                         !containsArray(maxPath,new int[]{rowIndex+1,colIndex+1})) {
    
                            //We use maxPath first, since this is the first 
                            //direction and by default is the longest
                            maxPath = getMaxPath (array, maxPath, rowIndex+1, colIndex+1);
                     } 
    
                     //If we can go one down, and it's a spot we have not
                     //yet visited
                     if (colIndex < colLength && 
                       array[rowIndex,colIndex+1]==1 && 
                       !containsArray(maxPath,new int[]{rowIndex,colIndex+1})) {
    
                           //We use futurePath now, since this is a second
                           //direction and a potential contender
                           futurePath = getMaxPath (array, maxPath, rowIndex, colIndex+1);
    
                          //We only need the maximum path.
                          if (futurePath.Count > maxPath.Count) {
                              maxPath = futurePath;
                          }
                     } 
    
                     //If we can go one down and one left, and it's a spot
                     //we have not yet visited
                     if (rowIndex>0 && colIndex < colLength && 
                        array[rowIndex-1,colIndex+1]==1 && 
                        !containsArray(maxPath,new int[]{rowIndex-1,colIndex+1})) {
    
                             futurePath = getMaxPath (array, maxPath, rowIndex-1, colIndex+1);
                             if (futurePath.Count > maxPath.Count) {
                                 maxPath = futurePath;
                             }
                     }
    
                     //If we can go one left, and it's a spot we have not
                     //yet visited
                     if (rowIndex>0 && 
                        array[rowIndex-1,colIndex]==1 && 
                        !containsArray(maxPath,new int[]{rowIndex-1,colIndex})) {
    
                             futurePath = getMaxPath (array, maxPath, rowIndex-1, colIndex);
                             if (futurePath.Count > maxPath.Count) {
                                 maxPath = futurePath;
                             }
                     }
                     //If we can go one left and one up, and it's a spot we
                     //have not yet visited
                     if (rowIndex>0 && colIndex>0 &&
                       array[rowIndex-1,colIndex-1]==1 && 
                       !containsArray(maxPath,new int[]{rowIndex-1,colIndex-1})) {
    
                         futurePath = getMaxPath (array, maxPath, rowIndex-1, colIndex-1);
                         if (futurePath.Count > maxPath.Count) {
                              maxPath = futurePath;
                         }
                     }                 
                     //If we can go one up, and it's a spot we have not yet
                     //visited
                     if (colIndex>0 &&
                         array[rowIndex,colIndex-1]==1 && 
                         !containsArray(maxPath,new int[]{rowIndex,colIndex-1})) {
    
                             futurePath = getMaxPath (array, maxPath, rowIndex, colIndex-1);
                             if (futurePath.Count > maxPath.Count) {
                                 maxPath = futurePath;
                             }
                     }
                     //If we can go one up and one right, and it's a spot we
                     //have not yet visited
                     if (colIndex>0 && rowIndex < rowLength &&
                       array[rowIndex+1,colIndex-1]==1 && 
                       !containsArray(maxPath,new int[]{rowIndex+1,colIndex-1})) {
    
                        futurePath = getMaxPath (array, maxPath, rowIndex+1, colIndex-1);
                        if (futurePath.Count > maxPath.Count) {
                             maxPath = futurePath;
                        }
                     }
                     //If we can go one right, and it's a spot we have not
                     //yet visited
                     if (rowIndex < rowLength &&
                       array[rowIndex+1,colIndex]==1 && 
                       !containsArray(maxPath,new int[]{rowIndex+1,colIndex})) {
    
                         futurePath = getMaxPath (array, maxPath, rowIndex+1, colIndex);
                         if (futurePath.Count > maxPath.Count) {
                             maxPath = futurePath;
                         }
                     }
    
                    //We return the max path. Note: If none of the directions around 
                    //us was applicable, we simply return the path we started 
                    //with with our cell included.
                    return maxPath;
              }
