'use strict';

module.exports = {
  async up (queryInterface, Sequelize) {
    await queryInterface.bulkInsert('Orders', [

      {

        fullname: 'pune 123',
        email:'anujadhs@gmail.com',
        phone: '45467689999',
        city: 'pune',
        zip: '343434',
        address:'pune mg road',
        state: 'Maharastra',
        country: 'India',
        status: 'pending',
        totalprice: 67.00,
       createdAt: new Date(),
       updatedAt: new Date()       

     },

     {

      fullname: 'pune 123',
      email:'anujadhs@gmail.com',
      phone: '45467689999',
      city: 'pune',
      zip: '343434',
      address:'pune mg road',
      state: 'Maharastra',
      country: 'India',
      status: 'pending',
      totalprice: 67.00,
     createdAt: new Date(),
     updatedAt: new Date()   

    },

    {

      fullname: 'pune 123',
        email:'anujadhs@gmail.com',
        phone: '45467689999',
        city: 'pune',
        zip: '343434',
        address:'pune mg road',
        state: 'Maharastra',
        country: 'India',
        status: 'pending',
        totalprice: 67.00,
       createdAt: new Date(),
       updatedAt: new Date()      

    }

    ], {});




  },

  async down (queryInterface, Sequelize) {
    /**
     * Add commands to revert seed here.
     *
     * Example:
     * await queryInterface.bulkDelete('People', null, {});
     */
  }
};
