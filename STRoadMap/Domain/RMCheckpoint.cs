//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class RMCheckpoint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RMCheckpoint()
        {
            this.CheckpointsSkills = new HashSet<CheckpointsSkill>();
            this.MentorCheckpointComments = new HashSet<MentorCheckpointComment>();
            this.UserCheckpointComments = new HashSet<UserCheckpointComment>();
        }
    
        public int Achieved { get; set; }
        public int RMCheckpointId { get; set; }
        public System.DateTime Deadline { get; set; }
        public int RoadMapId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckpointsSkill> CheckpointsSkills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MentorCheckpointComment> MentorCheckpointComments { get; set; }
        public virtual RoadMap RoadMap { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCheckpointComment> UserCheckpointComments { get; set; }
    }
}
