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
        public LoaiSPController()
        {
            loaiSpSvc = new LoaiSpSvc();
        }
        [HttpGet("GetById")]
        public IActionResult GetMaLoaiSP( int id)
        {
            var res = new SingleRsp();
            res = loaiSpSvc.Read(id);
            return Ok(res);
        }
        [HttpGet("GetAll")]
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
            res.Data = loaiSpReq;
            return Ok(res);
        }
        [HttpPut("Update")]
        public IActionResult UpDate(int Id, LoaiSpReq loaiSpReq)
        {
            var res = loaiSpSvc.UpdateCategory(Id,loaiSpReq);
            res.Data=loaiSpReq;
            return Ok(res);
        }
        [HttpDelete("DeletaById")]
        public IActionResult DeleteById(int id)
        {
            QuanLyMyPhamContext context = new QuanLyMyPhamContext();
            var l = loaiSpSvc.Read(id);
            if (l.Data != null)
            {
                context.Remove(l.Data);
                context.SaveChanges();
                return Ok(l);
            }
            return NotFound();
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
