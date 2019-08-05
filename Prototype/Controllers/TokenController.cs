﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Prototype.Interfaces;

namespace Prototype.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase {
        public readonly IJwtAuthenticate _jwt;
        public TokenController(IJwtAuthenticate jwt) {
            _jwt = jwt;
        }

        [HttpPost]
        public IActionResult Authenticate() {
            return Ok(_jwt.GenerateToken(new Claim[] {
                new Claim(ClaimTypes.Name, "SimpleAuth"),
            }));
        }
    }
}