'use strict';

module.exports = {
  async up (queryInterface, Sequelize) {
    

await queryInterface.bulkInsert('Users', [
  {
    firstName: 'Gayatri ',
    lastName: 'Patil',
    emailAdd: "gayatri@gmail.com",
    phoneNo:8989736453,
    address:"Pune",
    password:"gayu@123",
    confirmPassword:"gayu@123",
    createdAt: new Date(),
    updatedAt: new Date()
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
