using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicoSoap
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Comments> GetComments();

        [OperationContract]
        List<Comments> GetVideoComments(int videoId);

        [OperationContract]
        List<Ratings> GetRatings();

        [OperationContract]
        double GetVideoRatings(int videoId);

        [OperationContract]
        List<Videos> GetVideos();

        [OperationContract]
        Videos GetSingleVideo(string videoURL);

        [OperationContract]
        void NewComment(string comment, int videoID);

        [OperationContract]
        void NewRating(int score, int videoID);

        [OperationContract]
        void DeleteComment(int id);

        [OperationContract]
        void NewVideo(string name, string url, string description);

        [OperationContract]
        void DeleteVideo(int id);

    }

}
