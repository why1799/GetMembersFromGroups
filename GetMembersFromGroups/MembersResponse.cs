using System.Runtime.Serialization;

namespace GetMembersFromGroups
{
    [DataContract]
    class MembersResponse
    {
        [DataMember]
        public int count { get; set; }

        [DataMember]
        public int[] items { get; set; }
    }
}
