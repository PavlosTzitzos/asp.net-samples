using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace WebApplication2.Controllers
{
    public class IoTController : Controller
    {
        // GET: IoT
        public string Index()
        {
            return "This is the <b>default</b> index";
        }
        public string Device_Thermostat(double my_set = 25, int ID=1)
        {
            // A wall thermostat , connected to the internet ( home wifi )
            // current_temp is the room temperature
            // my_set is the temperature the user requires
            // device_connected is a boolean connected or not with the server
            // device_work is a boolean depedent from the temperatures

            double current_temp = 25.4;
            bool device_connected = true;
            bool device_work = false;
            string message = "nothing to do ... ";
            if (my_set > current_temp & device_connected)
            {
                device_work = true;
                // warm the house
                return HttpUtility.HtmlEncode("the temperature is: " + current_temp + ", the thermostat will work to reach the setted: "+ my_set + ". Device "+ID+" operates.");
            }
            else
            {
                return HttpUtility.HtmlEncode("Device "+ ID + " won't operate.");
            }
            // POST: 
        }

    }
}