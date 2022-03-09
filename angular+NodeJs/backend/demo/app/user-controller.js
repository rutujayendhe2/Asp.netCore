const { json } = require('body-parser');
const db = require('../db/models');
const bcrypt = require('bcrypt');
const saltRounds = 10;
const User = db.User;

//select * from people;
exports.findAll = (req, resp) => {
	User.findAll()
		.then((data) => { resp.json(data); })
		.catch((err) => {
			resp.status(500).send({
				message: err.message || " Something went"
			})
		})

}

exports.findByEmail = (req, resp) => {
	console.log("findByEmail called");
	const emailAdd = req.body.emailAdd;
	console.log("emailAdd=" + emailAdd);
	const password = req.body.password;

	User.findOne({ where: { emailAdd: emailAdd, password: password } })

		.then(data => {

			console.log(data);

			resp.send(data)
		})

		.catch((err) => {
			resp.status(500).send({
				message: err.message || ` Some error retriving Book data with id ${id}`
			})
		})
}

exports.findByPk = (req, resp) => {
	const id = req.params.id;

	User.findByPk(id)
		.then(data => { resp.send(data) })
		.catch((err) => {
			resp.status(500).send({
				message: err.message || ` Some error retriving Book data with id ${id}`
			})
		})
}


exports.create = (req, resp) => {
	if (!req.body.firstName) {
		res.status(400).send({
			message: "Content can not be empty!"
		});
		return;
	}
	const hash = bcrypt.hashSync(req.body.password, saltRounds);
	console.log('encyptedpassword', hash);

	const newUser = {
		firstName: req.body.firstName,
		lastName: req.body.lastName,
		emailAdd: req.body.emailAdd,
		phoneNo: req.body.phoneNo,
		address: req.body.address,
		password: hash,
		confirmPassword: req.body.confirmPassword
	}

	User.create(newUser)
		.then(data => {
			resp.json({
				message: 'Successfully registered'
			})
		})
		.catch((err) => {
			resp.status(500).send({
				message: err.message || " Some error Creating new Book data"
			})
		})
}

//update people set firstName=?, lastName=? where id=?
exports.update = (req, resp) => {
	const id = req.params.id;

	User.update(req.body, { where: { id: id } })
		.then(num => {
			if (num == 1) {
				resp.send({
					message: `Book with id ${id} updated successfully.`
				});
			} else {
				resp.send({
					message: `Cannot update Book with id=${id}. Maybe Book was not found or req.body is empty!`
				});
			}
		})
		.catch((err) => {
			resp.status(500).send({
				message: err.message || " Some error retriving Book data"
			})
		})
}

//delete from Book where id=?
exports.delete = (req, resp) => {
	const id = req.params.id;
	User.destroy({ where: { id: id } })
		.then(num => {
			if (num == 1) {
				resp.send({ message: `User with id=${id} deleted successfully!` });
			} else {
				resp.send({ message: `Cannot delete User with id=${id}. Maybe User was not found!` });
			}
		})
		.catch((err) => {
			resp.status(500).send({
				message: err.message || " Could not delete User with id=" + id
			})
		})
}
