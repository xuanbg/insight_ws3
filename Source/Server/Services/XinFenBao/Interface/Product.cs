using System;
using System.Collections.Generic;
using System.Linq;
using Insight.WS.Server.Common;
using Insight.WS.Server.Common.ORM;
using Insight.WS.Server.Common.YUN;

namespace Insight.WS.Service.XinFenBao
{
    public partial class Interface
    {

        /// <summary>
        /// 获取轮播广告列表
        /// </summary>
        /// <returns>轮播广告列表</returns>
        public List<BIZ_Advertiser> GetAdvertisers()
        {
            using (var context = new WSEntities())
            {
                var list = context.BIZ_Advertiser.ToList();
                foreach (var obj in list)
                {
                    obj.ImageURL = Util.GetAppSetting("ImageSite") + obj.ImageURL;
                }
                return list;
            }
        }

        /// <summary>
        /// 获取云商商品列表
        /// </summary>
        /// <param name="site"></param>
        /// <returns>云商商品列表</returns>
        public List<Products> GetProducts(string site)
        {
            using (var context = new YSEntities())
            {
                return context.Products.Where(p => p.Product_Site == site).ToList();
            }
        }

        /// <summary>
        /// 获取云商推荐商品列表
        /// </summary>
        /// <param name="site"></param>
        /// <returns>云商推荐商品列表</returns>
        public List<Products> GetRecProducts(string site)
        {
            using (var context = new YSEntities())
            {
                return context.Products.Where(p => p.Recommend && p.Product_Site == site).ToList();
            }
        }

        /// <summary>
        /// 获取云商分类商品列表
        /// </summary>
        /// <param name="category">分类名称</param>
        /// <param name="site"></param>
        /// <returns>云商分类商品列表</returns>
        public List<Products> GetCatProducts(string category, string site)
        {
            using (var context = new YSEntities())
            {
                return context.Products.Where(p => p.Category == category && p.Product_Site == site).ToList();
            }
        }

        /// <summary>
        /// 根据商品名称关键字查询云商商品
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="site"></param>
        /// <returns>云商商品列表</returns>
        public List<Products> FindProduct(string key, string site)
        {
            using (var context = new YSEntities())
            {
                return context.Products.Where(p => p.Name.ToUpper().Contains(key.ToUpper()) && p.Product_Site == site).ToList();
            }
        }

        /// <summary>
        /// 获取云商商品
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>云商商品对象</returns>
        public Products GetProduct(int id)
        {
            using (var context = new YSEntities())
            {
                return context.Products.FirstOrDefault(p => p.ID == id);
            }
        }

        /// <summary>
        /// 根据商品ID获取商品轮播图片
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>商品图片对象列表</returns>
        public List<Product_Library_Img> GetProductImage(int id)
        {
            using (var context = new YSEntities())
            {
                return context.Product_Library_Img.Where(i => i.Product_Img_ProductID == id).ToList();
            }
        }

        /// <summary>
        /// 获取商品可选参数集合
        /// </summary>
        /// <param name="pid">商品ID</param>
        /// <returns>商品可选参数集合</returns>
        public List<string> GetProductParm(int pid)
        {
            using (var context = new YSEntities())
            {
                var product = context.Products.Single(p => p.ID == pid);
                var parms = context.ProductType_Extend.Where(t => t.ProductType_Extend_ProductTypeID == product.TypeId).ToList();
                return (from parm in parms
                        let name = parm.ProductType_Extend_Name
                        let pe = context.Product_Library_Extend.Where(e => e.Product_Extend_ExtendID == parm.ProductType_Extend_ID).GroupBy(e => 
                        new {e.Product_Extend_ExtendID, e.Product_Extend_Value}).ToList()
                        select pe.Aggregate(name, (current, p) => current + ("," + p.Key.Product_Extend_Value))).ToList();
            }
        }

        /// <summary>
        /// 获取商品可选参数
        /// </summary>
        /// <param name="pid">商品ID</param>
        /// <returns>string 商品可选参数</returns>
        public List<string> GetProductParms(int pid)
        {
            using (var context = new YSEntities())
            {
                var parms = context.Product_Library_Extend.Where(e => e.Product_Extend_ProductID == pid).ToList();
                return (from parm in parms
                        let name = context.ProductType_Extend.Single(e => e.ProductType_Extend_ID == parm.Product_Extend_ExtendID).ProductType_Extend_Name
                        let value = parm.Product_Extend_Value
                        select $"{name},{value}").ToList();
            }
        }

        /// <summary>
        /// 根据所选参数获取商品ID
        /// </summary>
        /// <param name="parms">商品参数</param>
        /// <returns>int 商品ID</returns>
        public int GetProductId(string parms)
        {
            using (var context = new YSEntities())
            {
                var arr = parms.Split(',');
                var type = Convert.ToInt32(arr[0]);
                var list = context.Product_Library_Extend.Join(context.ProductType_Extend.Where(e => e.ProductType_Extend_ProductTypeID == type), 
                    pe => pe.Product_Extend_ExtendID, e => e.ProductType_Extend_ID, (pe, e) => pe).ToList();
                var ilist = new List<int>();
                for(var i =1; i<arr.Length;i++)
                {
                    list.FindAll(e => e.Product_Extend_Value == arr[i]).ToList().ForEach(e => ilist.Add(e?.Product_Extend_ProductID ?? 0));
                }
                var pid = (ilist.GroupBy(number => number).Select(i => new{number = i.Key,cnt = i.Count()})).OrderByDescending(num => num.cnt).First();
                return pid.number;
            }
        }

    }
}
