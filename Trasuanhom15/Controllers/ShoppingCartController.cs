using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using Trasuanhom15.Models;

namespace Trasuanhom15.Controllers
{
    public class ShoppingCartController : Controller
    {
        TrasuaDBEntities1 db = new TrasuaDBEntities1();

        //Chuan bi 1 cai gio hang
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
            {
                return View("ShowCart");
            }
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }


        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null||Session["Cart"]==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }


        public ActionResult AddToCart(int id)
        {
            var _pro = db.Products.SingleOrDefault(s => s.ProductID == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(Request.Form["idPro"]);
            int _quantity = int.Parse(Request.Form["carQuantity"]);
            cart.Update_quantity(id_pro,_quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            //Them
            if (cart.Items.Count() == 0)
            {
                cart = null;
                Session["Cart"] = null;
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public PartialViewResult BagCart()
        {
            decimal total_money_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                total_money_item = cart.Total_money();
            }
            ViewBag.TotalCart=total_money_item;
            return PartialView("BagCart");
        }

        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                OrderPro _order = new OrderPro();
                _order.DateOrder = DateTime.Now;
                //Quan trong
                _order.AddressDeliverry = form["AddressDeliverry"];
                _order.IDCus = int.Parse(form["CodeCustomer"]);
                db.OrderProes.Add(_order);
                foreach(var item in cart.Items)
                {
                    OrderDetail _order_detail = new OrderDetail();
                    _order_detail.IDOrder = _order.ID;
                    _order_detail.IDProduct = item._product.ProductID;
                    _order_detail.Quantity = item._quantity;
                    db.OrderDetails.Add(_order_detail);
                }
                db.SaveChanges();
                cart.ClearCart();
                //Them
                cart = null;
                Session["Cart"] = null;
                return RedirectToAction("CheckOut_Success", "ShoppingCart");
            }
            catch
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin");
            }
        }
        
        public ActionResult CheckOut_Success()
        {
            return View();
        }
    }
}