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

const getIdsFromSnapshot = (
  snapshot: FirebaseFirestore.QuerySnapshot<FirebaseFirestore.DocumentData>
) => {
  const result: string[] = [];
  snapshot.forEach((doc: FirebaseFirestore.DocumentData) => {
    if (doc.data() !== {}) {
      result.push(doc.id);
    }
  });
  return result;
};

export { parseDataFromSnapshot, getIdsFromSnapshot };
