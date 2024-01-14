using Client_ApplicationCore.DTO;
using Client_ApplicationCore.Interface;
using Client_Infrustructure;
using Client_Infrustructure.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace Client_UI.Controllers
{
    public class ClientController : Controller
    {

        private readonly IClient<Client> clientSerivce;
        private readonly ILookUp<LookUp> lookUpSerivce;

        public ClientController(IClient<Client> _clientSerivce, ILookUp<LookUp> _lookUpSerivce)
        {
            this.clientSerivce = _clientSerivce;
            this.lookUpSerivce = _lookUpSerivce;
        }

        public ActionResult Index(string valiueSearch=null)
        {
            List<VmClient> model = null;
            try
            {
                 ViewBag.LookUpList = lookUpSerivce.List();
                if (valiueSearch != null)
                {
                    var ClieListData = clientSerivce.Search(valiueSearch) != null ? clientSerivce.Search(valiueSearch) : clientSerivce.List();
                    model = ClieListData.Select(x => x.ToModel()).ToList();
                }
               else
                model = clientSerivce.List().Select(x => x.ToModel()).ToList();

                return View(model);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);

        }

      
        public ActionResult CreateOrEdit(int id = 0)
        {

            VmClient model = new VmClient();
            try
            {
                if (id == 0)
                {
                    model.MaritalStatusList = lookUpSerivce.List().ToList();

                }
                else
                {
                    var target = clientSerivce.Find(id);

                    if (target == null) return Index();

                    model = target.ToModel();
                    model.MaritalStatusList = lookUpSerivce.List().ToList();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(int id, VmClient model)
        {
            try
            {
                model.MaritalStatusList = lookUpSerivce.List().ToList();
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        
                        var MS = model.MaritalStatus ?? default(int);
                        Client target = new Client() { FirstName = model.FirstName,
                            LastName = model.LastName, MaritalStatus = model.MaritalStatus,MobileNumber=model.MobileNumber,
                        Email=model.Email,DateofBirth=model.DateofBirth,Image=model.Image};
                        clientSerivce.Add(target);
                    }
                    else
                    {
                       
                        var target = clientSerivce.Find(model.Id);
                        target.FirstName = model.FirstName;
                        target.LastName = model.LastName;
                        target.MobileNumber = model.MobileNumber;
                        target.Email = model.Email;
                        target.DateofBirth = model.DateofBirth;
                        target.Image = model.Image;
                        target.MaritalStatus=model.MaritalStatus;

                        clientSerivce.Update(target);

                    }
                    return RedirectToAction("index");
                }

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("index");

        }

       

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
                clientSerivce.Delete(id);
                var clients = clientSerivce.List();
                return Json(clients);
            }
           else
            return RedirectToAction("Index");
        }
    }

}
