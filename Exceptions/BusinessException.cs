namespace Exam.Exceptions
{
    public enum ErrorCode{
       
  }
    public class BusinessException:Exception
    {
        public BusinessException(string message):base(message) { }
    }
}
