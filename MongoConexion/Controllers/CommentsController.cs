using System;
using Microsoft.AspNetCore.Mvc;
using MongoConexion.Services;
using MongoConexion.Models;

namespace MongoConexion.Controllers;

[Controller]
[Route("api/[controller]")]
public class CommentsController: Controller{

    private readonly MongoDBService _mongoDBService;
    public CommentsController(MongoDBService mongoDBService){

        _mongoDBService= mongoDBService;
    }

    [HttpGet]
    public async Task<List<Comments>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Comments comments) {
        await _mongoDBService.CreateAsync(comments);
        return CreatedAtAction(nameof(Get), new { id= comments.Id}, comments);

    }
}
