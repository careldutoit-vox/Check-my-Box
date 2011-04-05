﻿namespace NoStressWedding.Areas.DBManagement.Models {
	public class UserRole {
		public int UserRoleId { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
	}
}