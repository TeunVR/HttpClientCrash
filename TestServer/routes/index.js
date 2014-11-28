var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res) {
  res.render('index', { title: 'Express' });
});

router.get('/get', function(req,res) {
  console.log("new get");
  setTimeout(function() {
  	res.json({user:'A GET'});
  }, 2000);
});

router.post('/post', function(req, res) {
  console.log("new post");
  setTimeout(function() {
  	res.json({user:'A POST'});
  }, 2000);
});

module.exports = router;
