using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.Models;
using BLL.Services;
using WebApplication.Models;
using PagedList;

namespace WebApplication.Controllers
{
    public class HomeController : Controller//todo pn мог бы и переименовать контроллер)
	{
        private OrderService orderService;
        private ProductService productService;

        public HomeController()
        {
            this.orderService = new OrderService();
            this.productService = new ProductService();
        }

        public ActionResult Index(int page = 1)
        {
            var pageSize = 15;//todo pn в константы
            var orders = Mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderViewModel>>(this.orderService.GetAllOrders());
            return this.View(orders.ToPagedList(page, pageSize));
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
            this.orderService.DeleteOrder(orderID);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditOrder(int? orderID)
        {
            if (orderID == null)
            {
                this.ViewData["ModalDialogHead"] = "Добавление заказа";//todo pn в ресурсы
				this.ViewData["ModalBtnSubmit"] = "Добавить";//todo pn в ресурсы
				return this.PartialView(new EditOrderViewModel());
            }

            this.ViewData["ModalBtnSubmit"] = "Изменить";//todo pn в ресурсы
			this.ViewData["ModalDialogHead"] = "Изменение заказа";//todo pn в ресурсы
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