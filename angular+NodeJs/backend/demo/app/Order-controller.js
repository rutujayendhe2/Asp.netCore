const db=require('../db/models');//index.js=>db
const Item=require('../db/models').Item;
const User=require('../db/models').User;

const Orders=db.Orders;

// 1. select * from users => findAll
exports.findAll=(req,resp)=>{
    Orders.findAll()
        .then(data=>resp.json(data))
        .catch(err=>{
            resp.status(500)
                .send({message:err.message||
                `Something went wrong`})
        });
};

// 2. seelct * from users where id=?=>findByPK

exports.findByPk=(req,resp)=>{
    const id=parseInt(req.params.id);
    Orders.findByPk(id)
        .then(data=>resp.json(data))
        .catch(err=>{
            resp.status(500)
                .send({message:err.message||
                `Something went wrong`})
        });
};
///3.
exports.create = (req, resp) => {
    if(!req.body.fullname){
        resp.status(400).send({
            message: "Content can not be empty!"
        });
        return;
    }
    const newOrders={
        fullname:req.body.fullname,
        email:req.body.email,
        phone:req.body.phone,
        city:req.body.city,
        zip:req.body.zip,
        address:req.body.address,
        state:req.body.state,
        country:req.body.country,
        status:req.body.status,
        totalprice:req.body.totalPrice
      
    }
    Orders.create(newOrders)
        .then(data=>{resp.json({
            message:'suceesful order'
        })
    })
        .catch((err) => {
            resp.status(500).send({
                message: err.message || " Some error Creating new Order data"
            })
        })
}
///4.
exports.update = (req, resp) => {
    const id = req.params.id;

    Orders.update(req.body, { where: { id: id } })
        .then(num => {
            if (num == 1) {
            resp.send({
                message: `Order with id ${id} updated successfully.`
            });
            } else {
            resp.send({
                message: `Cannot update User with id=${id}. Maybe Order was not found or req.body is empty!`
            });
            }
        })
        .catch((err) => {
            resp.status(500).send({
                message: err.message || " Some error retriving Order data"
            })
        })
}
//5
exports.delete = (req, resp) => {
    const id = req.params.id;
    Orders.destroy({ where: { id: id } })
        .then(num => {
            if (num == 1) {
                resp.send({ message: `Order with id=${id} deleted successfully!` });
            } else {
                resp.send({ message: `Cannot delete Order with id=${id}. Maybe Order was not found!` });
            }
        })
        .catch((err) => {
            resp.status(500).send({
                message: err.message || " Could not delete Order with id=" + id
            })
        })
}