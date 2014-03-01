﻿/****************************************************************/
/*                                                              */
/* Author: Dragonsangel                                         */
/* E-Mail: drag0nsang3l@gmail.com                               */
/* BTC   : 1P8RuwZuRdmBfrXdURSaxsoJzUPfBEvBie                   */
/*         Donations are welcome                                */
/*                                                              */
/****************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CEX.io.API.ApiObjects
{
  public class TradeHistoryList : List<TradeHistory>
  {
    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();
      foreach (TradeHistory item in this)
      {
        outputString.AppendLine(item.ToString());
      }

      return outputString.ToString();
    }
  }

  [DataContract]
  public class TradeHistory
  {
    [DataMember(Name="tid")]
    public int TradeId { get; set; }
    [DataMember(Name = "amount")]
    public decimal TradeAmount { get; set; }
    [DataMember(Name = "price")]
    public decimal Price { get; set; }
    [DataMember(Name = "date")]
    public double date { get; set; }

    public DateTime Timestamp
    {
      get
      {
        DateTime convertDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        convertDateTime = convertDateTime.AddSeconds(date).ToLocalTime();
        return convertDateTime;
      }
    }

    public override string ToString()
    {
      StringBuilder outputString = new StringBuilder();

      outputString.AppendLine(string.Format("TradeID     = {0}", TradeId));
      outputString.AppendLine(string.Format("TradeAmount = {0}", TradeAmount));
      outputString.AppendLine(string.Format("Price       = {0}", Price));
      outputString.AppendLine(string.Format("TimeStamp   = {0}", Timestamp));

      return outputString.ToString();
    }
  }
}
