﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLMP.BLL;
using QLMP.Common.Req;
using QLMP.Common.Rsp;
using QLMP.DAL.Models;

namespace QLMP.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSPController : ControllerBase
    {
        private LoaiSpSvc loaiSpSvc;
        public  LoaiSPController()
        {
            loaiSpSvc =  new LoaiSpSvc();
        }
        [HttpPost("GetById")]
        public IActionResult GetMaLoaiSP([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = loaiSpSvc.Read(simpleReq.Id);
            return Ok(res);
        }
        [HttpPost("GetAll")]
        public IActionResult GetAllLoaiSP()
        {
            var res = new SingleRsp();
            res.Data = loaiSpSvc.All;
            return Ok(res);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] LoaiSpReq loaiSpReq)
        {
            var res = new SingleRsp();
            res = loaiSpSvc.CreateCategory(loaiSpReq);
            return Ok(res);
        }
        [HttpPut("Update")]
        public IActionResult UpDate([FromBody] LoaiSpReq loaiSpReq)
        {
            var res = loaiSpSvc.UpdateCategory(loaiSpReq);
            return Ok(res);
        }
        [HttpDelete("DeletaById")]
        public IActionResult DeleteById(int id)
        {
            QuanLyMyPhamContext context = new QuanLyMyPhamContext();
            var l = loaiSpSvc.Read(id);
            context.Remove(l.Data);
            context.SaveChanges();
            return Ok(l);
        }
        [HttpPost("SeachByName")]
        public IActionResult SeachByName(SearchCateByName searchCateByName)
        {
            var res = new SingleRsp();
            res = loaiSpSvc.SearchCategory(searchCateByName);
            return Ok(res);
        }
       
    }
}