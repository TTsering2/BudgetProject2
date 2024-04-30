using Microsoft.AspNetCore.Mvc;
using Budgets.Models;
using Budgets.Services;
using Budgets.Data;


namespace Budget.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase {
    private readonly IStockServices _stockServices;

    public StockController(IStockServices stockServices){
        _stockServices = stockServices;
    }

    /// <summary>
    /// Get all Stocks for a given User.
    /// </summary>
    /// <param name="UserId">The ID of the User.</param>
    /// <returns>An ActionResult containing the list of Stocks.</returns>
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

    /// <summary>
    /// Get a Stock by Id.
    /// </summary>
    /// <param name="Id">The ID of the Stock.</param>
    /// <returns>An ActionResult containing the Stock.</returns>
    [HttpGet("{Id}")]
    public ActionResult<Stock> GetStockById(int Id) {
        Stock stock = _stockServices.GetStockById(Id);
        if (stock == null){
            return NotFound("This stock does not exist.");
        }
        return Ok(stock);
    }

    /// <summary>
    /// Add a Stock.
    /// </summary>
    /// <param name="stock">The Stock object to be added.</param>
    /// <returns>An ActionResult containing the newly added Stock.</returns>
    [HttpPost]
    public ActionResult<Stock> AddStock(Stock stock){
        Stock newStock = _stockServices.AddStock(stock);
        return newStock;
    }

    /// <summary>
    /// Update a Stock.
    /// </summary>
    /// <param name="Id">The ID of the Stock to be updated.</param>
    /// <param name="stock">The updated Stock object.</param>
    /// <returns>An ActionResult containing the updated Stock.</returns>
    [HttpPut("{Id}")]
    public ActionResult<Stock> UpdateStock(int Id, Stock stock){
        if(stock == null){
            return BadRequest("Id does not match.");
        }
        Stock updatedStock = _stockServices.UpdateStock(stock);
        return updatedStock;
    }

    /// <summary>
    /// Delete a Stock.
    /// </summary>
    /// <param name="Id">The ID of the Stock to be deleted.</param>
    /// <returns>An ActionResult containing the deleted Stock.</returns>
    [HttpDelete("{Id}")]
    public ActionResult<Stock?> DeleteStock(int Id){
        Stock deletedStock = _stockServices.DeleteStock(Id);
        if(deletedStock == null){
            return NotFound("Stock not found.");
        }
        return deletedStock;
    }
}

