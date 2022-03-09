'use strict';

module.exports = {
  async up (queryInterface, Sequelize) {
    await queryInterface.bulkInsert('productlists', [
      {
        title: 'Tomatoes',
        price: 40,
        description: 'Fresh red tomatoes',
        category: 'Fruits',
        image: '../../../assets/images/product-2.png',
      createdAt:new Date(),
      updatedAt:new Date()
      },
      {
        title: 'Onions',
        price: 70,
        description: 'Fresh Onions',
        category: 'Bulbs',
        image: '../../../assets/images/product-7.png',
      createdAt:new Date(),
      updatedAt:new Date()
      },
      {
        title: 'Carrots',
        price: 50,
        description: 'Fresh Carrots',
        category: 'Root and Tubers',
        image: '../../../assets/images/product-9.png',
      createdAt:new Date(),
      updatedAt:new Date()
      },
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
