using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LogServices;
public interface Ilog
{
public string FilePath{get;set;}
 public void WriteMessage(string message);

}
