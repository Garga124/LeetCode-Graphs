/*
Complexity
Time complexity: O(n⋅m)
Space complexity: O(n⋅m)

↪ where n is the number of rows and m is the number of columns in the image matrix. 
The space complexity contribution comes from the frames on the call stack created by the recursive operation.
*/
public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
         if(color == image[sr][sc])
         {
            return image;
         }
         DFS(image,sr,sc,color,image[sr][sc]);
         return image;
    }
    private void DFS(int[][] image,int row, int col, int color, int oldColor)
    {
        if(row<0 || row >=image.GetLength(0) || col<0 || col>=image[0].Length || image[row][col] != oldColor)
        {
            return;
        }

        image[row][col] = color;

        DFS(image,row-1,col,color,oldColor);
        DFS(image,row+1,col,color,oldColor);
        DFS(image,row,col-1,color,oldColor);
        DFS(image,row,col+1,color,oldColor);
    }
}