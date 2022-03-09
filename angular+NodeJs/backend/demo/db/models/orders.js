'use strict';
const {
  Model
} = require('sequelize');
module.exports = (sequelize, DataTypes) => {
  class Orders extends Model {
    /**
     * Helper method for defining associations.
     * This method is not a part of Sequelize lifecycle.
     * The `models/index` file will call this method automatically.
     */
    static associate(models) {
      // define association here
    }
  }
  Orders.init({
    fullname: DataTypes.STRING,
    email: DataTypes.STRING,
    phone: DataTypes.STRING,
    city: DataTypes.STRING,
    zip: DataTypes.STRING,
    address: DataTypes.STRING,
    state: DataTypes.STRING,
    country: DataTypes.STRING,
    status: DataTypes.STRING,
    totalprice: DataTypes.NUMERIC
  }, {
    sequelize,
    modelName: 'Orders',
  });
  return Orders;
};