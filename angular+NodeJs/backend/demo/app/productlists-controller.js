const db =require('../db/models');
const productlists=db.productlists;

// Select * from productlists => findAll() => http://localhoast:3000/app/productlists

exports.findAll=(req,resp)=>{
    productlists.findAll()
        .then(data=>resp.json(data))
        .catch(err=>{
            resp.status(500)
                 .send({message:err.message||
                 `Something went wrong`})
    });
};

// Select * from productlists where bookid= ? => findByPK() => http://localhoast:3000/app/productlists/?
exports.findByPK=(req,resp)=>{

    const id=parseInt(req.params.id);
    productlists.findByPk(id)
        .then(data=>resp.json(data))
        .catch(err=>{
            resp.status(500)
                .send({message:err.message||
                `Something went wrong`})
        });
};

// Insert into productlists ==> createBook() => http://localhoast:3000/app/productlists/add
exports.createproductlists=(req,resp)=>{
    if(!req.body.title){
        resp.status(400).send({
            message: "Product title can not be empty!"
        });
        return;
    }
    if(!req.body.price){
        resp.status(400).send({
            message: "Product price can not be empty!"
        });
        return;
    }
    if(!req.body.description){
        resp.status(400).send({
            message: "Product description can not be empty!"
        });
        return;
    }
    if(!req.body.category){
        resp.status(400).send({
            message: "Product category can not be empty!"
        });
        return;
    }
    if(!req.body.image){
        resp.status(400).send({
            message: " Product image can not be empty!"
        });
        return;
    }
    const newproductlists={
        title: req.body.title,
        price: req.body.price,
        description: req.body.description,
        category: req.body.category,
        image: req.body.image,
        createdAt:new Date(),
        updatedAt:new Date()
    }
    productlists.create(newproductlists)
        .then(data=>{resp.send(data);})
        .catch((err) => {
            resp.status(500).send({
                message: err.message || " Some error Creating new Book data"
            });
        });
};

//Update productlists SET book where id= ? => updateBook() => http://localhoast:3000/app/productlists/?
exports.updateproductlists=(req,resp)=>{
    const id = req.params.id;
	
    productlists.update(req.body, { where: { id: id } })
        .then(num => {
            if (num == 1) {
            resp.send({
                message: `productlists with id ${id} updated successfully.`
            });
            } else {
            resp.send({
                message: `Cannot update productlists with id=${id}. Maybe book was not found or req.body is empty!`
            });
            }
        })
        .catch((err) => {
            resp.status(500).send({
                message: err.message || " Some error retriving People data"
            })
        })
};

// Delete productlists where id=? => deleteBook() => http://localhoast:3000/app/productlists/?
exports.deleteproductlists=(req,resp)=>{
    const id = req.params.id;

    productlists.destroy({ where: { id: id } })
        .then(num => {
            if (num == 1) {
                resp.send({ message: `Book with id=${id} deleted successfully!` });
            } else {
                resp.send({ message: `Cannot delete Book with id=${id}. Maybe Book was not found!` });
            }
        })
        .catch((err) => {
            resp.status(500).send({
                message: err.message || " Could not delete Book with id=" + id
            })
        })
};