using System.Runtime.Serialization;

namespace Moments.Classes
{
    [DataContract]
     public class TodosClass
    {
        [DataMember] public int AlbumId { get; set; }
        [DataMember] public string title { get; set; }
        [DataMember] public string url{ get; set; }
        [DataMember] public string thumbnailUrl { get; set; }
    }
}
