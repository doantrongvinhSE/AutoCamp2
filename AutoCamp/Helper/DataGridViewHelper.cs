using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCamp.Helper
{
   public class DataGridViewHelper
    {
        public static void CheckAll(DataGridView grid, string columnName, bool state)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Cells[columnName].Value = state;
            }
        }


        public static void CheckSelected(DataGridView grid, string columnName, bool state)
        {
            foreach (DataGridViewCell cell in grid.SelectedCells)
            {
                grid.Rows[cell.RowIndex].Cells[columnName].Value = state;
            }
        }


        public static void RemoveSelectedRows(DataGridView grid)
        {
            // Tạo danh sách các chỉ số hàng cần xóa
            List<int> rowsToRemove = new List<int>();

            // Thu thập tất cả các chỉ số hàng có ô được chọn
            foreach (DataGridViewCell cell in grid.SelectedCells)
            {
                if (!rowsToRemove.Contains(cell.RowIndex))
                {
                    rowsToRemove.Add(cell.RowIndex);
                }
            }

            // Sắp xếp theo thứ tự giảm dần để xóa từ dưới lên trên
            rowsToRemove.Sort();
            rowsToRemove.Reverse();

            // Xóa các hàng
            foreach (int rowIndex in rowsToRemove)
            {
                grid.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
