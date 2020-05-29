import * as Ajv from "ajv";

import { parseDataFromSnapshot, getIdsFromSnapshot } from "../utils";
import { ClassModel } from "./class.types";
import * as schema from "./class.schema.json";

const admin = require("firebase-admin");

class ClassService {
  private ajv: Ajv.Ajv;
  private collection: FirebaseFirestore.CollectionReference;
  constructor() {
    admin.initializeApp();

    const db = admin.firestore();
    this.collection = db.collection("classes");
    this.ajv = new Ajv();
  }
  getClasses(): Promise<{ classes: ClassModel[] }> {
    return new Promise((resolve, reject) =>
      this.collection
        .get()
        .then((snapshot) => {
          resolve({
            classes: parseDataFromSnapshot(snapshot),
          });
        })
        .catch((err: any) => {
          reject(err);
        })
    );
  }

  getClass(className: string): Promise<ClassModel> {
    return new Promise((resolve, reject) =>
      this.collection
        .where("className", "==", className)
        .get()
        .then((snapshot) => {
          resolve(parseDataFromSnapshot(snapshot)[0]);
        })
        .catch((err: any) => {
          reject(err);
        })
    );
  }

  getClassId(className: string): Promise<string> {
    return new Promise((resolve, reject) =>
      this.collection
        .where("className", "==", className)
        .get()
        .then((snapshot) => {
          resolve(getIdsFromSnapshot(snapshot)[0]);
        })
        .catch((err: any) => {
          reject(err);
        })
    );
  }

  postClass(newClass: ClassModel): Promise<ClassModel> {
    return new Promise((resolve, reject) =>
      this.collection
        .doc()
        .set(newClass)
        .then(() => {
          resolve(newClass);
        })
        .catch((err: any) => {
          reject(err);
        })
    );
  }

  putClass(classId: string, newClass: ClassModel): Promise<ClassModel> {
    return new Promise((resolve, reject) =>
      this.collection
        .doc(classId)
        .set(newClass)
        .then(() => {
          resolve(newClass);
        })
        .catch((err: any) => {
          reject(err);
        })
    );
  }

  deleteClass(classId: string): Promise<FirebaseFirestore.WriteResult> {
    return this.collection.doc(classId).delete();
  }

  validate(data: any) {
    const isValid = this.ajv.validate(schema, data);
    if (!isValid) {
      const errorMessages = this.ajv.errorsText();
      throw new Error(`Validation Error. ${errorMessages}`);
    }
    return data;
  }
}

module.exports = ClassService;
