import pytest

def test_createFaceSet(client):

    # check if pass nothig
    with pytest.raises(AttributeError):
        client.createFaceSet()

    #create a faceset
    fake_outer_id = 'fakeSet'
    client.createFaceSet(outer_id = fake_outer_id)
    # check if FaceSet is created
    response = client.getFaceSetDetail(outer_id = fake_outer_id)
    assert "error_message" not in response

    client.deleteFaceSet(outer_id = fake_outer_id)


def test_deleteFaceSet(client):

    with pytest.raises(AttributeError):
        client.deleteFaceSet()

    with pytest.raises(AttributeError):
        client.deleteFaceSet(outer_id = "fiss", faceset_token = "aca2e06780a707b8cac736a71be546b0")

    with pytest.raises(AttributeError):
        client.deleteFaceSet(outer_id = "fiss", check_empty = "-1")

    with pytest.raises(AttributeError):
        client.deleteFaceSet(outer_id = "fiss", check_empty = -1)

    with pytest.raises(AttributeError):
        client.deleteFaceSet(outer_id = "fiss", check_empty = 2)

    #create a faceset
    fake_outer_id = 'fakeSet'
    client.createFaceSet(outer_id = fake_outer_id)
    # check if FaceSet is deleted
    response = client.deleteFaceSet(outer_id = fake_outer_id)
    assert "error_message" not in response


def test_getFaceSetDetail(client):

    with pytest.raises(AttributeError):
        client.getFaceSetDetail()

    with pytest.raises(AttributeError):
        client.getFaceSetDetail(outer_id = "fiss", faceset_token = "aca2e06780a707b8cac736a71be546b0")

    with pytest.raises(AttributeError):
        client.getFaceSetDetail(faceset_token = "aca2e06780a707b8cac736a71be546b0", start = -1)

    with pytest.raises(AttributeError):
        client.getFaceSetDetail(faceset_token = "aca2e06780a707b8cac736a71be546b0", start = 10001)

    with pytest.raises(AttributeError):
        client.getFaceSetDetail(faceset_token = "aca2e06780a707b8cac736a71be546b0", start = "10001")

    #create a faceset
    fake_outer_id = 'fakeSet'
    client.createFaceSet(outer_id = fake_outer_id)
    # check if FaceSet is created
    response = client.getFaceSetDetail(outer_id = fake_outer_id)
    assert "error_message" not in response
    assert response['face_count'] == 0
    client.deleteFaceSet(outer_id = fake_outer_id)


def test_updateFaceSet(client, filepath):

    # check if pass nothig
    with pytest.raises(AttributeError):
        client.updateFaceSet()

    with pytest.raises(AttributeError):
        client.updateFaceSet(outer_id = "fiss", faceset_token = "aca2e06780a707b8cac736a71be546b0")

    #create fake FaceSet
    res = client.detect(file = filepath)
    fake_face_token = res['faces'][0]['face_token']
    fake_outer_id = 'fakeSet'
    client.createFaceSet(outer_id = fake_outer_id, face_tokens = [fake_face_token])

    # get detail new FaceSet
    faceSet = client.getFaceSetDetail(outer_id = fake_outer_id)
    del faceSet["request_id"]
    del faceSet["time_used"]
    new_outer_id = "new_Fake_id"
    faceSet.update({"outer_id": new_outer_id})

    # Update face set appenna creato
    client.updateFaceSet(outer_id = fake_outer_id, new_outer_id = new_outer_id)
    new_faceSet = client.getFaceSetDetail(outer_id = "new_Fake_id")
    del new_faceSet["request_id"]
    del new_faceSet["time_used"]

    # controllo se le modifiche effettuate
    assert new_faceSet == faceSet

    #delete created FaceSet
    client.deleteFaceSet(outer_id = new_outer_id)

def test_getFaceSets(client, filepath):
    #check tags attribute
    with pytest.raises(AttributeError):
        client.getFaceSets(tags = 10)

    #check start attribute
    with pytest.raises(AttributeError):
        client.getFaceSets(start = -1)

    #check start attribute
    with pytest.raises(AttributeError):
        client.getFaceSets(start = "100")

    #check if facesets is void
    assert client.getFaceSets()["facesets"] == []

    #check if information retrived is valid
    res = client.detect(file = filepath)
    fake_face_token = res['faces'][0]['face_token']
    fake_outer_id = 'fakeSet'

    #create fake FaceSet
    client.createFaceSet(outer_id = fake_outer_id, face_tokens = [fake_face_token])

    assert client.getFaceSets()["facesets"][0]["outer_id"] == fake_outer_id

    assert len(client.getFaceSets()["facesets"]) == 1

    assert len(client.getFaceSets(start = 2)["facesets"]) == 0

    #delete created FaceSet
    client.deleteFaceSet(outer_id = fake_outer_id)

def test_add_remove_Face(client, filepath):
    #detect a face
    res = client.detect(file = filepath)
    #get token
    fake_face_token = res['faces'][0]['face_token']
    fake_outer_id = 'fakeSet'

    #create a faceset and add the detected token
    client.createFaceSet(outer_id = fake_outer_id)
    response = client.addFace(outer_id = fake_outer_id, face_tokens = [fake_face_token])

    #check face_token if successfully added
    assert response['face_added'] == 1

    response = client.removeFace(outer_id = fake_outer_id, face_tokens = [fake_face_token])

    #check face_token if successfully removed
    assert response['face_removed'] == 1

    #delete created FaceSet
    client.deleteFaceSet(outer_id = fake_outer_id)

    with pytest.raises(TypeError):
        client.addFace()

    with pytest.raises(AttributeError):
        client.addFace(face_tokens = [fake_face_token, fake_face_token, fake_face_token, fake_face_token, fake_face_token, fake_face_token])

    with pytest.raises(TypeError):
        client.removeFace()

    l = ["a" for i in range(1002)]
    with pytest.raises(AttributeError):
        client.removeFace(face_tokens = l)
