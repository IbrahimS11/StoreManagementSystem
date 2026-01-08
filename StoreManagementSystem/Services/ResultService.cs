namespace StoreManagementSystem.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; } = true;
        public object? Data { get; set; }  
        public List<Dictionary<string,string>> Errors { get; set; } = new();


        public ResultService() { }
        private ResultService(object id)
        {
            Data = id;
        }
        private ResultService(bool isSuccess, Dictionary<string,string>? error)
        {
            IsSuccess = isSuccess;
            if(error != null)
            {
                Errors.Add(error);
            } 
        }
        


        public static ResultService Success(object data) => new(data);

        public static ResultService Success() => new();

        public static ResultService Failure(string key , string error)
            => new(false, new Dictionary<string, string> { [key]=error });

        public void AddError(string key, string error)
        {
            Errors.Add(new Dictionary<string, string> { [key] = error });
        }

           

    }
}
