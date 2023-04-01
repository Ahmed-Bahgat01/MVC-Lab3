using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class DepartmentRepo : EntityRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(Context _context) : base(_context)
        {
        }

        /// <summary>
        ///     this method searches for student by Id updates all it's values
        /// </summary>
        /// <param name="newDepartment"></param>
        /// <returns>
        ///     Student : new updated student
        ///     null : if student not found
        /// </returns>
        public Department? Update(Department? newDepartment)
        {
            Department? toBeUpdated = null;
            if (newDepartment is not null)
            {
                toBeUpdated = GetById(newDepartment.Id);
                if (toBeUpdated != null)
                {
                    toBeUpdated = newDepartment;
                }
            }
            
            return toBeUpdated;
        }
    }
}
