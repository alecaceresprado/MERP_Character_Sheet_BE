import express = require("express");

import { ClassModel } from "./class.types";
const ClassService = require("./Class.service");

const classController: express.Router = express.Router();

const classService = new ClassService();

const schemaValidator = (req: any, res: any, next: any) => {
  try {
    classService.validate(req.body);
    next();
  } catch ({ message }) {
    res.status(400).json({ message });
  }
};

classController.get("", (req, res) => {
  classService.getClasses().then((response: any) => {
    res.json(response);
  });
});

classController.get("/:className", (req, res) => {
  classService.getClass(req.params.className).then((response: ClassModel) => {
    if (!response) {
      res
        .status(404)
        .send(`No class found under name: ${req.params.className}`);
    }
    res.json(response);
  });
});

classController.post("", schemaValidator, (req, res) => {
  classService.getClass(req.body.className).then((found: ClassModel) => {
    if (!found) {
      classService.postClass(req.body).then((response: ClassModel) => {
        res.json(response);
      });
    } else {
      res.status(422).json({
        error: `There is another class created under the name: ${found.className}`,
        class: found,
      });
    }
  });
});

export { classController };
