using Microsoft.AspNetCore.Mvc;
using Budgets.Models;
using Budgets.Services;
using Budgets.Data;


namespace Budget.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase {
    private readonly IStockRepository _stockRepository;
    private readonly IStockServices _stockServices;

    public StockController(IStockRepository stockRepository, IStockServices stockServices){
        _stockRepository = stockRepository;
        _stockServices = stockServices;
    }




    // Get all Stocks for a given User  
    [HttpGet("user/{UserId}")]
    public ActionResult<IEnumerable<Stock>> GetAllStocksForUser(int UserId){
        
        try {
            IEnumerable<Stock> Stocks = _stockServices.GetAllStocksForUser(UserId);

                if(Stocks == null || !Stocks.Any()){
                    return NotFound("No Stocks found for the given User.");
                }

                return Ok(Stocks);
            } 
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving Stocks by author: {ex.Message}");
            }    
    }



    // Get a Stock by Id  
    [HttpGet("{Id}")]
    public ActionResult<Stock> GetStockById(int Id) {

        Stock stock = _stockServices.GetStockById(Id);
        if (stock == null){
            return NotFound("this stock does not exist");
        }
        return Ok(stock);
    }


    // Add a Stock
    [HttpPost]
     public ActionResult<Stock> AddStock(Stock stock){
        
        Stock newStock = _stockServices.AddStock(stock);
        return newStock;

    }

    //update a stock
    [HttpPut("{Id}")]
    public ActionResult<Stock> UpdateStock(int Id, Stock stock){
        if(stock == null){
            return BadRequest("Id does not match");
        }
        Stock updatedStock = _stockServices.UpdateStock(stock);
        return updatedStock;
    }

    // delete a stock
    [HttpDelete("{Id}")]
    public ActionResult<Stock?> DeleteStock(int Id){
        Stock deletedStock = _stockServices.DeleteStock(Id);
        if(deletedStock == null){
            return NotFound("Stock not found");
        }
        return deletedStock;
    }
}

