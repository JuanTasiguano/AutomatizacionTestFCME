using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanTasiguano
{
    public class Ntest
    {

        //Se Inicializa el driver de manera global

        public IWebDriver driver = new ChromeDriver(@"C:\Users\jtasiguano\source\repos\JuanTasiguano\JuanTasiguano\Chrome");
        //intancia de manera global la URL de la pagian a testear//intancia de manera global la URL de la pagian a testear
        public string url = "https://admin-sysnnova.com/OpenFact/Account/Logisysnnova.com/OpenFact/Account/Login.aspx?AspxAutoDetectCookieSupport=1";

        //generacion del metodo de prueba
        [Test]
        public void Registro()
        {
            ITakesScreenshot ScreenShotDrive = driver as ITakesScreenshot;
            Screenshot screenshot = ScreenShotDrive.GetScreenshot();
            try
            {
                //seteo de la pagina a probar
                driver.Navigate().GoToUrl(url);
                //se maximiza la pagina
                driver.Manage().Window.Maximize();
                //instancia del campo para login campo USER
                driver.FindElement(By.Id("LoginUser_UserName"));
                driver.FindElement(By.Id("LoginUser_UserName")).Click();
                driver.FindElement(By.Id("LoginUser_UserName")).SendKeys("Demo");
                //instancia del campo para login campo PASS
                driver.FindElement(By.Id("LoginUser_Password"));
                driver.FindElement(By.Id("LoginUser_Password")).Click();
                driver.FindElement(By.Id("LoginUser_Password")).SendKeys("0430");

                //Pausa para procerder a dar click 
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                //Click en login 
                driver.FindElement(By.Id("LoginUser_LoginButton")).Click();

                //Hasta este momento logueo exitoso
                screenshot.SaveAsFile(@"C:\Users\jtasiguano\source\repos\JuanTasiguano\JuanTasiguano\Save\" + " LogueoOK "+ ".png");

                WebDriverWait wait2 = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

                driver.FindElement(By.Id("liClientes")).Click();
                Thread.Sleep(3000);
                WebDriverWait wait3 = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

                driver.FindElement(By.Id("MainContent_btnAdd")).Click();
                Thread.Sleep(2000);
                WebDriverWait wait4 = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

                driver.FindElement(By.Id("MainContent_txtNombreCliente"));
                driver.FindElement(By.Id("MainContent_txtNombreCliente")).Click();
                driver.FindElement(By.Id("MainContent_txtNombreCliente")).SendKeys("Juan Tasiguano");
                Thread.Sleep(2000);
                driver.FindElement(By.Id("MainContent_txtIdentificacion"));
                driver.FindElement(By.Id("MainContent_txtIdentificacion")).Click();
                driver.FindElement(By.Id("MainContent_txtIdentificacion")).SendKeys("0918241746");
                Thread.Sleep(2000);
                driver.FindElement(By.Id("MainContent_txtTelefonoConvencional"));
                driver.FindElement(By.Id("MainContent_txtTelefonoConvencional")).Click();
                driver.FindElement(By.Id("MainContent_txtTelefonoConvencional")).SendKeys("042530221");
                Thread.Sleep(2000);


                var TipoIdent = driver.FindElement(By.Id("MainContent_ddlTipoIdentificacion"));
                var selectElement = new SelectElement(TipoIdent);
                selectElement.SelectByValue("05");

                IWebElement Check1 = driver.FindElement(By.Id("MainContent_cbxEnviarBienvenida"));
                Check1.Click();

                Thread.Sleep(2000);

                driver.FindElement(By.Id("MainContent_btnGuardarCliente")).Click();
                Thread.Sleep(4000);
                screenshot = ScreenShotDrive.GetScreenshot();
                screenshot.SaveAsFile(@"C:\Users\jtasiguano\source\repos\JuanTasiguano\JuanTasiguano\Save\ProcesoOK" + DateTime.Now.Ticks.ToString() + ".png");
            }
            catch (Exception ex)
            {
                screenshot.SaveAsFile(@"C:\Users\jtasiguano\source\repos\JuanTasiguano\JuanTasiguano\Save\" + " Error " + ".png");
                driver.Close();
            }
        }

    }

    }
