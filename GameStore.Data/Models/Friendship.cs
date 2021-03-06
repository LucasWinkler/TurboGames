﻿using GameStore.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Models
{
    /// <summary>
    /// The status code for the friendship request between two registered users.
    /// </summary>
    public enum FriendStatusCode { Pending = 0, Accepted = 1, Rejected = 2 }

    /// <summary>
    /// A friendship between two registered users.
    /// 
    /// The Sender is the User which is sending the friend request.
    /// The Receiver is the User who is being sent a friend requiest.
    /// The RequestStatus is either Accepted, Rejected or None (pending).
    /// 
    /// If a request is already made and the opposite user creates another
    /// request to the user who is sending them a request then the system
    /// should accept the first request rather than create a new one.
    /// </summary>
    public class Friendship
    {
        [Required]
        public string SenderId { get; set; }

        [Required]
        public User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        public User Receiver { get; set; }

        [Required]
        public bool IsFamily { get; set; }

        [Required]
        public FriendStatusCode RequestStatus { get; set; } = FriendStatusCode.Pending;
    }
}
