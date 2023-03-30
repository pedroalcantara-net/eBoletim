using eBoletimServer.Domain.Models;

namespace eBoletim.Server.CrossCutting
{
    public static class Util
    {
        public static ReturnObject CreateBadRequest(string reason)
        {
            return new ReturnObject()
            {
                Status = false,
                Message = reason,
                Code = 400
            };
        }
        public static ReturnObject CreateInternalServerError(Exception ex)
        {
            return new ReturnObject()
            {
                Status = false,
                Message = ex.Message,
                Code = 500
            };
        }
    }
}
