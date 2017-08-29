using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.Models;
using BLL.Services;
using HWT_13.Resources;
using WebApplication.Models;
using PagedList;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private OrderService orderService;
        private ProductService productService;
        private const int PageSize = 15;

        public HomeController()
        {
            this.orderService = new OrderService();
            this.productService = new ProductService();
        }

        public ActionResult Index(int page = 1)
        {
            Session["CurPage"] = page;
            var orders = Mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderViewModel>>(this.orderService.GetAllOrders());
            return this.View(orders.ToPagedList(page, PageSize));
        }

        public ActionResult Details(int? orderID)
        {
            if (orderID == null)
            {
                return this.HttpNotFound();
            }

            var order = Mapper.Map<OrderDetailsDTO, OrderInfoViewModel>(this.orderService.GetOrderDetails(orderID.Value));
            return this.PartialView(order);
        }

        [HttpGet]
        public ActionResult ConfirmDelete(int orderID)
        {
            return this.PartialView(orderID);
        }

        [HttpPost]
        public ActionResult DeleteOrder(int orderID)
        {
            var s = Session["CurPage"];
            this.orderService.DeleteOrder(orderID);
            return this.RedirectToAction("Index", new { page = Session["CurPage"] });
        }

        [HttpGet]
        public ActionResult EditOrder(int? orderID)
        {
            if (orderID == null)
            {
                this.ViewData["ModalDialogHead"] = ViewRecources.TittleAddOrder;
                this.ViewData["ModalBtnSubmit"] = ViewRecources.NameBtnAddOrder;
                return this.PartialView(new EditOrderViewModel());
            }

            this.ViewData["ModalBtnSubmit"] = ViewRecources.NameBtnEditOrder;
            this.ViewData["ModalDialogHead"] = ViewRecources.TittleEditOrder;
            var targetOrder = Mapper.Map<OrderDTO, EditOrderViewModel>(this.orderService.GetOrder(orderID.Value));
            return this.PartialView(targetOrder);
        }

        [HttpPost]
        public ActionResult EditOrder(EditOrderViewModel orderVm)
        {
            if (this.ModelState.IsValid)
            {
                var newOrder = Mapper.Map<EditOrderViewModel, OrderDTO>(orderVm);
                newOrder.Customer = Mapper.Map<EditOrderViewModel, CustomerDTO>(orderVm);
                if (orderVm.OrderID == null)
                {
                    this.orderService.AddOrder(newOrder);
                }
                else
                {
                    this.orderService.EditOrder(newOrder);
                }
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel product)
        {
            if (this.ModelState.IsValid)
            {
                var productDTO = Mapper.Map<AddProductViewModel, ProductDetailsDTO>(product);
                if (this.productService.AddProduct(productDTO))
                {
                    return this.PartialView(product);
                }
            }

            return this.HttpNotFound();
        }

        [HttpPost]
        public JsonResult GetProducts()
        {
            var listProducts = this.productService.GetAllProducts();
            return this.Json(listProducts);
        }
    }
}