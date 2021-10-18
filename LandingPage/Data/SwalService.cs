using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace LandingPage.Data
{
    public static class SwalService
    {
        public static async Task showMessage(this IJSRuntime js, string title, string message,
            typeMessage swal)
        {
            await js.InvokeVoidAsync("Swal.fire", title, message, swal.ToString());
        }

        public enum typeMessage
        {
            success, question, error, warning, info
        }
    }
}
