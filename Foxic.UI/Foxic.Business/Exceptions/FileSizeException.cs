﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxic.Business.Exceptions
{
	public class FileSizeException : Exception
	{
		public FileSizeException( string message) : base(message) 
		{
		}
		
	}
}
