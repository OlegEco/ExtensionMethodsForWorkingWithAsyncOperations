using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsForWorkingWithAsyncOperations
{
    internal static class TaskExtensions
    {
        public static async Task<T> WithTimeout<T>(this Task<T> task, int timeout)
        {
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task) // waiting completed Task or TImeOut
            {
                return await task;
            }
            else
            {
                throw new TimeoutException("The operation has timed out."); // if exception then TimeoutException
            }
        }
    }
}
