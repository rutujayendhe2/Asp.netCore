module.exports=(app)=>{

    const express=require('express');
    const ROUTER=express.Router();
    const UserController=require('./user-controller');
    ROUTER.get('/users',UserController.findAll);
    ROUTER.get('/users/:id',UserController.findByPk);
    ROUTER.post('/users/add',UserController.create);
    ROUTER.put('/user/update/:id',UserController.update);
    ROUTER.delete('/users/delete/:id',UserController.delete);
    ROUTER.post('/users/login',UserController.findByEmail);



    const OrederController=require('./Order-controller');
    ROUTER.get('/orders',OrederController.findAll);
    ROUTER.get('/orders/:id',OrederController.findByPk);
    ROUTER.post('/orders/add',OrederController.create);
    ROUTER.put('/orders/update/:id',OrederController.update);
    ROUTER.delete('/orders/delete/:id',OrederController.delete);


    const ProductListController=require('./productlists-controller');
    ROUTER.get('/productlists',ProductListController.findAll);
    ROUTER.get('/productlists/:id',ProductListController.findByPK);
    ROUTER.post('/productlists/add',ProductListController.createproductlists);
    ROUTER.put('/productlists/update/:id',ProductListController.updateproductlists);
    ROUTER.delete('/productlists/delete/:id',ProductListController.deleteproductlists);
 

    app.use('/app',ROUTER);


}