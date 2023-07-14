//using EmbedIO;
//using EmbedIO.Routing;
//using EmbedIO.WebApi;

//namespace ClipboardMonitor.Listener;

//public class LocalCombatManagerServiceController : WebApiController//, ILocalCombatManagerService
//{ 
//    Action saveCallback; 

//    public LocalCombatManagerServiceController(IHttpContext context)

//    {
//    }


        
        

//    [Route(HttpVerbs.Get, "/combat/state")]
//    public async Task<object> GetCombatState()
//    {
//        return await TakeAction((res) =>
//        {
//            res.Data = state.ToRemote();
//        });
//    }

//    [Route(HttpVerbs.Get, "/combat/next")]
//    public async Task<object> CombatNext()
//    {
//        return await TakeAction((res) =>
//        {
//            state.MoveNext();
//            saveCallback();
//            res.Data = state.ToRemote();
//        });
//    }

//    [Route(HttpVerbs.Get, "/combat/prev")]
//    public async Task<object> CombatPrev()
//    {

//        return await TakeAction((res) =>
//        {
//            state.MovePrevious();
//            saveCallback();
//            res.Data = state.ToRemote();
//        });
//    }
         

 

//    private async Task<object> TakeAction(Action<ResultHandler> resAction)
//    {
            
//        try
//        {
//            ResultHandler res = new ResultHandler();


//            //actionCallback(() =>
//            //{
//            //    try
//            //    {
//            //        resAction(res);
//            //    }
//            //    catch (Exception)
//            //    {
//            //        res.Failed = true;
//            //    }

//            //});
//            if (res.Failed)
//            {
//                throw new HttpException(res.Code);
//            }

//            return await Task.FromResult(res.Data);
//        }
//        catch (Exception ex)
//        {
//            throw new HttpException(System.Net.HttpStatusCode.InternalServerError, ex.ToString());
//        } 
//    }
         

//    private async Task<object> TakePostAction<T>(Action<ResultHandler, T> resAction) where T : class
//    {

       
//        try
//        {
//            ResultHandler res = new ResultHandler();
//            T data = await HttpContext.GetRequestDataAsync<T>();

//            if (data == null)
//            {
//                res.Failed = true;
//            }
     
//            if (res.Failed)
//            {
//                throw new HttpException(res.Code, new ArgumentException().ToString());
//            } 
//            return res.Data;
                

//        }
//        catch (Exception ex)
//        {
//            throw new HttpException(System.Net.HttpStatusCode.InternalServerError, ex.ToString());
//        } 
//    }

//    //private async Task<object> TakeCharacterPostAction<T>(Action<ResultHandler, T, Character> resAction) where T : CharacterRequest
//    //{
//    //    return await TakePostAction<T>((res, data) =>
//    //    {

//    //        Character ch = state.GetCharacterByID(data.ID);
//    //        if (ch != null)
//    //        {
//    //            try
//    //            {
//    //                resAction(res, data, ch);
//    //            }
//    //            catch
//    //            {
//    //                res.Failed = true;
//    //            }
//    //        }
//    //        else
//    //        {
//    //            res.Failed = true;
//    //        }

//    //    });
//    //}



//}