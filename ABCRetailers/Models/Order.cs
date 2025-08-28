﻿
// Models/Order.cs
using Azure;
using Azure.Data.Tables;
using Bogus.DataSets;
using Microsoft.Exchange.WebServices.Data;
using System.ComponentModel.DataAnnotations;

namespace ABCRetailers.Models
{

    public class Order : ITableEntity
    {

        public string PartitionKey { get; set; } = "Order";

        public string RowKey { get; set; } = Guid.NewGuid().ToString();

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        [Display(Name = "Order ID")]

        public string OrderId => RowKey;

 [Required]
        [Display(Name = "Customer")]

        public string CustomerId { get; set; } = string.Empty;

        [Display(Name = "Username")]

        public string Username { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Product")]

        public string ProductId { get; set; } = string.Empty;

        [Display(Name = "Product Name")]

        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]

public DateTime OrderDate { get; set; } = DateTime.Today;

        [Required]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]


        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]

        public double UnitPrice { get; set; }

        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]

        public double TotalPrice { get; set; }

        [Required]
        [Display(Name = "Status")]

        public string Status { get; set; } = "Submitted";


        public enum OrderStatus { Submitted, // When order is first created
            Processing, // When company opens/reviews the order
            Completed, // When order is delivered to customer
            Cancelled // When order is cancelled
        }
    }
}