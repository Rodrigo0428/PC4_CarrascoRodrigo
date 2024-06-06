using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.Extensions.ML;
using PC4_ML;
using PC4.DataStructures;
using PC4.Services;

namespace pc4_progra.Controllers
{
    public class MLController : Controller
    {
        private readonly ILogger<MLController> _logger;
        private readonly PredictionEnginePool<ProductoRating, ProductoRatingPrediction> _model;
        private readonly ProductoService _productoService;


        public MLController(ILogger<MLController> logger,
        PredictionEnginePool<ProductoRating, ProductoRatingPrediction> model,
        ProductoService productoService)
        {
            _logger = logger;
            _model = model;
            _productoService = productoService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
public IActionResult Predict(int id)
        {
            List<(int productoId, float normalizedScore)> ratings = new List<(int productoId, float normalizedScore)>();
            ProductoRatingPrediction prediction = null;

            foreach (var producto in _productoService.getAllProductos())
            {
                // Call the Rating Prediction for each movie prediction
                prediction = _model.Predict(new ProductoRating
                {
                    userid = id,
                    productoid = producto.ProductoId // Asegúrate de que coincide con el nombre de la propiedad en ProductoRating
                });

                // Normalize the prediction scores for the "ratings" b/w 0 - 100
                float normalizedscore = Sigmoid(prediction.Score);

                // Add the score for recommendation of each movie in the trending movie list
                ratings.Add((producto.ProductoId, normalizedscore));
            }
            ViewData["ratings"] = ratings;
            ViewData["trendingproductos"] = _productoService.getAllProductos();
            return View("Index");
        }

   



        public float Sigmoid(float x)
        {
            return (float) (100/(1 + Math.Exp(-x)));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}