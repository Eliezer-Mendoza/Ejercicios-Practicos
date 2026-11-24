from imutils.video import VideoStream
import argparse
import imutils
import time
import cv2

ap = argparse.ArgumentParser()
ap.add_argument("-v", "--video", type=str,
                help="ruta para insertar el video de prueba")
# el video es para apuntar hacia la ruta del video, valga la redundancia

ap.add_argument("-t", "--tracker", type= str, default="kcf",
                help = "opencv trackeador de objetos")
args = vars(ap.parse_args())
# el t es uno de los sietes modelos disponibles, el kcf es el por default pero se puede escoger entre los 7 que existen sin ningun probema

opencv_object_trackers = {
    "csrt": cv2.legacy.TrackerCSRT_create,
    "kcf": cv2.legacy.TrackerKCF_create,
    "boosting": cv2.legacy.TrackerBoosting_create,
    "mil": cv2.legacy.TrackerMIL_create,
    "tld": cv2.legacy.TrackerTLD_create,
    "medianflow": cv2.legacy.TrackerMedianFlow_create,
    "mosse": cv2.legacy.TrackerMOSSE_create
}

trackers = cv2.legacy.MultiTracker_create()

#lo siguiente es que si no se le asigna una ruta escoge webcam por default

if not args.get("video", False):
    print("[!] Se encenderá la webcam")
    vs = VideoStream(src=0).Start()
    time.sleep(1.0)
else:
    vs = cv2.VideoCapture(args["video"])
    

# ahora comparar los frames para no hacer bucles inf y saber cuando termina un video

while True:
    frame = vs.read()
    frame = frame[1] if args.get("frame", False) else frame
    if Frame is None:
        break
    
    frame = imutils.resize(frame, width=600)
    

# muestra frame
    cv2.imshow("Frame", frame)
    tecla = cv2.waitKey(1) & 0xFF

    # si la tecla s se presiona vamos a seleccionar para trackear
    if tecla == ord("s"):
        box = cv2.selectROI("Frame", frame, fromCenter=False,
                            showCrosshair=True)
        tracker = opencv_object_trackers[args["tracker"]]()
        trackers.add(tracker, frame, box)
    elif tecla == ord("q"):
        break
if not args.get("video", False):
    vs.stop()
else:
    vs.release()
    
cv2.destroyAllWindows()