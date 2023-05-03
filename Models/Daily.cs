using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiWeather.Models
{
	public class Daily
	{

		public List<string>? Time { get; set; }
		public List<double>? Temperature_2m_min { get; set; } 

		public List<double>? Temperature_2m_max { get; set; } 
		public List<double>? Snowfall_sum { get; set; }

		public List<double>? Temperature_2m_min_F
		{
			get
			{
				if (Temperature_2m_min != null)
				{
					List<double> temp = new List<double>();
					this.Temperature_2m_min.ForEach(x => temp.Add(((x * 9) / 5) + 32));
					return temp;
				}
				return null;
			}

		}
		public List<double>? Temperature_2m_max_F
		{
			get
			{
				if (Temperature_2m_max != null)
				{
					List<double> temp = new List<double>();
					this.Temperature_2m_max.ForEach(x => temp.Add(((x * 9) / 5) + 32));
					return temp;
				}
				return null;
			}
		}
	}

}

