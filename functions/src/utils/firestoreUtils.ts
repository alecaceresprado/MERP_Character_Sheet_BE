const parseDataFromSnapshot = (
  snapshot: FirebaseFirestore.QuerySnapshot<FirebaseFirestore.DocumentData>
) => {
  const result: any[] = [];
  snapshot.forEach((doc: FirebaseFirestore.DocumentData) => {
    if (doc.data() !== {}) {
      result.push(doc.data());
    }
  });
  return result;
};

export { parseDataFromSnapshot };
