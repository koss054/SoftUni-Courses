﻿namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class BaseController : Controller
    {
    }
}
